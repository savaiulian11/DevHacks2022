import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.prod';
import { ActivityType } from '../Models/ActivityType';

@Injectable({
  providedIn: 'root'
})
export class ActivityTypeService {

  constructor(private http: HttpClient) {}

  getAll(): Observable<ActivityType[]>{
    return this.http.get<ActivityType[]>(environment.URL+"/Activity_Types/GetAll");
  }

  post(ActivityType:ActivityType){
    return this.http.post<ActivityType>(environment.URL+"/Activity_Types",ActivityType);
  }

  put(ActivityType:ActivityType){
    return this.http.put<ActivityType>(environment.URL+"/Activity_Types",ActivityType);
  }

  delete(id:number){
    return this.http.delete(environment.URL + "/Activity_Types" + id);
  }
}
