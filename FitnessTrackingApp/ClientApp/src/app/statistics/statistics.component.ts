import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-statistics',
  templateUrl: './statistics.component.html',
  styleUrls: ['./statistics.component.css']
})
export class StatisticsComponent implements OnInit {
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
  constructor() { }

  ngOnInit(): void {
  }

}
