import { Injectable, NgModule } from '@angular/core';
import { Http, Response, Headers, RequestOptions, URLSearchParams }
    from '@angular/http';
import { Observable } from 'rxjs/Observable';

// Observable class extensions
import 'rxjs/add/observable/of';
import 'rxjs/add/observable/throw';

// Observable operators
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/debounceTime';
import 'rxjs/add/operator/distinctUntilChanged';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/filter';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/switchMap';

@Injectable()
export class AppService {

    private handleError(error: any): any {
        let errMsg = (error.message) ? error.message :
            error.status ? `${error.status} - ${error.statusText}` : 'Server error';
        return Observable.throw(errMsg);
    }
    private extractMatch(res: any): any {
        let body = res.json();
        return body || {};
    }

    private baseUrl: string = `http://192.168.43.164:9122/api/`;
    // private baseUrl: string = `http://192.168.100.101:9122/api/`;
    // private baseUrl: string = `http://localhost:9122/api/`;

    constructor(private http: Http) { }

    public getMatch(id: number) {
        return this.http.get(`${this.baseUrl}/Score/${id}`, {})
            .map(this.extractMatch)
            .catch(this.handleError);
    }

    public setTimeLeft(id: number, timeLeft: number) {
        return this.http.post(`${this.baseUrl}/SetTimeLeft/${id}/${timeLeft}`, {})
            .map(this.extractMatch)
            .catch(this.handleError);
    }

    public plusHome(id: number) {
        return this.http.post(`${this.baseUrl}/GoalForHomeTeam/${id}`, {})
            .map(this.extractMatch)
            .catch(this.handleError);
    }
    public plusAway(id: number) {
        return this.http.post(`${this.baseUrl}/GoalForAwayTeam/${id}`, {})
            .map(this.extractMatch)
            .catch(this.handleError);
    }
    public minusHome(id: number) {
        return this.http.post(`${this.baseUrl}/RemoveFromHomeTeam/${id}`, {})
            .map(this.extractMatch)
            .catch(this.handleError);
    }
    public minusAway(id: number) {
        return this.http.post(`${this.baseUrl}/RemoveFromAwayTeam/${id}`, {})
            .map(this.extractMatch)
            .catch(this.handleError);
    }
}

export class Entity {
    Id: number;
}
export class Match extends Entity {
    MatchTime: Date;
    Score: Score;
}

export class Score extends Entity {
    Match: Match;

    TimeLeft: number;

    HomeTeamGoals: number;
    AwayTeamGoals: number;

    HomeTeam: Team;
    AwayTeam: Team;
}

export class Team extends Entity {
    Name: string;
    Player1: string;
    Player2: string;
}