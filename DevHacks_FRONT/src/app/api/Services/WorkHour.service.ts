import { Injectable } from '@angular/core';
import { WorkHour } from '../Models/WorkHour';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.prod';

@Injectable({
  providedIn: 'root'
})
export class WorkHourService {

  constructor(private http: HttpClient) {}

  getAll(): Observable<WorkHour[]>{
    return this.http.get<WorkHour[]>(environment.URL+"/WorkHour/GetAll");
  }

  post(WorkHour:WorkHour){
    return this.http.post<WorkHour>(environment.URL+"/WorkHour",WorkHour);
  }

  put(WorkHour:WorkHour){
    return this.http.put<WorkHour>(environment.URL+"/WorkHour",WorkHour);
  }

  delete(id:number){
    return this.http.delete(environment.URL + "/WorkHour" + id);
  }
}
