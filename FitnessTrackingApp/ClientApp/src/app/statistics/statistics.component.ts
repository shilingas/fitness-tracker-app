import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HistoryModel } from '../models/HistoryModel';
import { HistoryModelArray } from '../models/HistoryModelArray';
import { User } from '../models/User';
import { DataService } from '../services/data-service/data.service';

@Component({
  selector: 'app-statistics',
  templateUrl: './statistics.component.html',
  styleUrls: ['./statistics.component.css']
})
export class StatisticsComponent implements OnInit {
  updatedGoalWeight: number = 0;
  bmi: number = 0;
  chartOption = {
    title: {
      text: 'Line Chart Example'
    },
    tooltip: {
      trigger: 'axis'
    },
    legend: {
      data: ['Series A', 'Series B']
    },
    xAxis: {
      type: 'category',
      data: ['Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat', 'Sun']
    },
    yAxis: {
      type: 'value'
    },
    series: [
      {
        name: 'Series A',
        type: 'line',
        data: [120, 132, 101, 134, 90, 230, 210]
      },
      {
        name: 'Series B',
        type: 'line',
        data: [220, 182, 191, 234, 290, 330, 310]
      }
    ]
  };
  constructor(private dataService: DataService, private router: Router) { }
  user!: User;
  message: string = '';
  weightHistory: HistoryModelArray[] = [];
  userId!: string;
  weight: number = 0; // Property to hold weight input value
  ngOnInit(): void {
    this.dataService.getUserIdByUsername(this.dataService.getUserName()).subscribe((x: any) => {
      this.user = x;
      this.userId = x.id;
      console.log(x);
      this.bmi = (this.user.weight / this.user.heigth / this.user.heigth) * 10000;
      this.fetchWeightHistory();
    })
  }
  logOut() {
    this.router.navigate(['']);
  }
  fetchWeightHistory() {
    this.dataService.getWeightHistoryByUserId(this.userId).subscribe((history: HistoryModelArray[]) => {
      this.weightHistory = history.sort((a, b) => new Date(a.updatedDate).getTime() - new Date(b.updatedDate).getTime());
      this.updateChart();
    });
  }


  addWeightHistory() {
    if (this.weight > 0) {
      const newHistory: HistoryModel = {
        userId: this.userId, // Assuming user has an id property
        newWeight: this.weight
      };
      this.dataService.createWeightHistory(newHistory).subscribe((response) => {
        console.log('Weight history added:', response);
        this.weight = 0;
        this.fetchWeightHistory();
      }, (error) => {
        console.error('Error adding weight history:', error);
      });
    } else {
      console.error('Weight should be greater than 0.');
    }
  }

  updateGoalWeight() {
    this.dataService.getUserIdByUsername(this.dataService.getUserName()).subscribe((x: any) => {
      this.user = x;
      this.userId = x.id;
      const newUser: User = {
        name: this.user.name,
        surname: this.user.surname,
        phoneNumber: this.user.phoneNumber,
        weight: this.user.weight,
        heigth: this.user.heigth,
        goalWeight: this.updatedGoalWeight
      }
      this.dataService.updateGoalWeight(this.userId, newUser).subscribe((x: User) => {
        console.log('updated user weight');
        this.updatedGoalWeight = 0;
        this.dataService.getUserIdByUsername(this.dataService.getUserName()).subscribe((x: any) => {
          this.user = x;
        })
      })
    })
  }

  updateChart() {
    const dates = this.weightHistory.map(item => new Date(item.updatedDate).getTime()); // Convert dates to timestamps
    const weights = this.weightHistory.map(item => Number(item.newWeight)); // Convert newWeight to numbers

    this.chartOption = {
      title: {
        text: 'Weight History'
      },
      tooltip: {
        trigger: 'axis' // Specify the tooltip trigger type
      },
      legend: {
        data: ['Weight History'] // Specify legend data if needed
      },
      xAxis: {
        type: 'category',
        data: dates.map(date => new Date(date).toLocaleDateString()) // Convert timestamps back to formatted dates
      },
      yAxis: {
        type: 'value'
      },
      series: [
        {
          name: 'Weight History', // Set the name of the series
          type: 'line',
          data: weights
        }
      ]
    };
  }




}
