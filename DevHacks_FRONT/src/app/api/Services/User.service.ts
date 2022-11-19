import { Injectable } from '@angular/core';
import { Afiliere } from '../Models/Afiliere';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.prod';

@Injectable({
  providedIn: 'root'
})
export class AfiliereService {

  constructor(private http: HttpClient) {}

  getAll(): Observable<Afiliere[]>{
    return this.http.get<Afiliere[]>(environment.URL+"/Afiliere/GetAll");
  }

  post(afiliere:Afiliere){
    return this.http.post<Afiliere>(environment.URL+"/Afiliere",afiliere);
  }

  put(afiliere:Afiliere){
    return this.http.put<Afiliere>(environment.URL+"/Afiliere",afiliere);
  }

  delete(id:number){
    return this.http.delete(environment.URL + "/Afiliere" + id);
  }
}
