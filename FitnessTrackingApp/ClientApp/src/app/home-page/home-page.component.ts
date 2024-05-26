import { Component, OnInit } from '@angular/core';
import { DataService } from '../services/data-service/data.service';
import { TestModel } from '../models/TestModel';
import { User } from '../models/User';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css'],
})
export class HomePageComponent {
  selectedIndex = 0;

  onTabChange(index: number) {
    this.selectedIndex = index;
  }
  constructor(private dataService: DataService) {

  }
  ngOnInit() {
    this.dataService.getUserIdByUsername(this.dataService.getUserName()).subscribe((x: any) => {
      console.log(x);
    })
  }

}
