import { Injectable } from '@angular/core';
import { Reward } from '../Models/Reward';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.prod';

@Injectable({
  providedIn: 'root'
})
export class RewardService {

  constructor(private http: HttpClient) {}

  getAll(): Observable<Reward[]>{
    return this.http.get<Reward[]>(environment.URL+"/Reward/GetAll");
  }

  post(Reward:Reward){
    return this.http.post<Reward>(environment.URL+"/Reward",Reward);
  }

  put(Reward:Reward){
    return this.http.put<Reward>(environment.URL+"/Reward",Reward);
  }

  delete(id:number){
    return this.http.delete(environment.URL + "/Reward" + id);
  }
}
