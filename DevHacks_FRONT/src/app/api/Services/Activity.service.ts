import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.prod';
import { Activity } from '../Models/Activity';

@Injectable({
  providedIn: 'root'
})
export class ActivityService {

  constructor(private http: HttpClient) {}

  getAll(): Observable<Activity[]>{
    return this.http.get<Activity[]>(environment.URL+"/Activities/GetAll");
  }

  post(Activity:Activity){
    return this.http.post<Activity>(environment.URL+"/Activities",Activity);
  }

  put(Activity:Activity){
    return this.http.put<Activity>(environment.URL+"/Activities",Activity);
  }

  delete(id:number){
    return this.http.delete(environment.URL + "/Activities" + id);
  }
}
