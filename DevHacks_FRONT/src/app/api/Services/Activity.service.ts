import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.prod';
import { Activity } from '../Models/Activity';

@Injectable({
  providedIn: 'root'
})
export class AfiliereService {

  constructor(private http: HttpClient) {}

  getAll(): Observable<Activity[]>{
    return this.http.get<Activity[]>(environment.URL+"/Activity/GetAll");
  }

  post(Activity:Activity){
    return this.http.post<Activity>(environment.URL+"/Activity",Activity);
  }

  put(Activity:Activity){
    return this.http.put<Activity>(environment.URL+"/Activity",Activity);
  }

  delete(id:number){
    return this.http.delete(environment.URL + "/Activity" + id);
  }
}
