import { Component, ViewContainerRef } from '@angular/core';
import { AppService, Match, Entity, Score, Team } from './app.service';
import { OnInit } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Http, Response, Headers, RequestOptions, URLSearchParams }
  from '@angular/http';
import { NgIf } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  extractData(data: any): Score {
    console.log(data);
    return data as Score;
  }

  Math: any;
  Score: any;
  hidden: boolean;
  matchNumber: any = 1;
  TimeLeft: number = undefined;

  interval: any;
  timer: any;
  MatchDefaultTime: number = 300;
  loading: boolean;

  ngOnInit(): void {
    this.Math = Math;
    this.startCount();
  }
  title = '1º Campeonato de Pebolim!';

  constructor(private service: AppService, private http: Http) {
    this.service = new AppService(http);
  }

  startCount() {
    var a = this;
    this.interval = setInterval(() => {
      if (!!this.loading)
        return;

      this.loading = true;
      a.service.getMatch(a.matchNumber).subscribe(data => {
        a.Score = data;
        this.loading = false;
        if (!a.TimeLeft)
          a.TimeLeft = a.Score.TimeLeft;
      }, error => {
        console.log(error);
        this.loading = false;
      });
    }, 500);
  }

  startTimer() {
    var a = this;
    if (!!this.timer)
      return;
    this.timer = setInterval(() => {
      a.TimeLeft--;
      if (a.TimeLeft < 0) {
        a.stopTimer();
        a.TimeLeft = 0;
        return;
      }
      a.service.setTimeLeft(a.matchNumber, a.TimeLeft).subscribe(data => {
        a.Score = data;
      }, error => console.log(error));
    }, 1000);
  }

  stopTimer() {
    clearInterval(this.timer);
    this.timer = undefined;
  }
  resetTimer() {
    var a = this;
    a.service.setTimeLeft(a.matchNumber, this.MatchDefaultTime).subscribe(data => {
      a.Score = data;
      a.TimeLeft = a.Score.TimeLeft;
    }, error => console.log(error));
  }

  plusHome() {
    this.service.plusHome(this.matchNumber).subscribe(data => { }, error => console.log(error));
  }
  plusAway() {
    this.service.plusAway(this.matchNumber).subscribe(data => { }, error => console.log(error));
  }
  minusHome() {
    this.service.minusHome(this.matchNumber).subscribe(data => { }, error => console.log(error));
  }
  minusAway() {
    this.service.minusAway(this.matchNumber).subscribe(data => { }, error => console.log(error));
  }
}
