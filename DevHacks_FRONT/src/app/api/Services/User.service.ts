import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.prod';
import { User } from '../Models/User';
import { LoginWrapper } from '../Wrappers/LoginWrapper';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) {}

  getAll(): Observable<User[]>{
    return this.http.get<User[]>(environment.URL+"/Users/GetAll");
  }

  login(login:LoginWrapper) {
    return this.http.post<any>(environment.URL+"/Users/Login",login);
  }

  post(User:User){
    return this.http.post<User>(environment.URL+"/Users/Post",User);
  }

  put(User:User){
    return this.http.put<User>(environment.URL+"/Users/Put",User);
  }

  delete(id:number){
    return this.http.delete(environment.URL + "/Users/Delete" + id);
  }
}
