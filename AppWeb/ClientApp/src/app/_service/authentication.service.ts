import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { User } from '../_model/user';

import { ROOT_URL } from '../_model/config';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  private currentUserSubject: BehaviorSubject<User>;
  public currentUser: Observable<User>;

  constructor(private http: HttpClient) {
    this.currentUserSubject = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('currentUser')));
    this.currentUser = this.currentUserSubject.asObservable();
  }

  public get currentUserValue(): User {
    return this.currentUserSubject.value;
  }

  //login(username: string, password: string) {
  //  return this.http.post<any>(`/users/authenticate`, { username, password })
  //    .pipe(map(user => {
  //      // login successful if there's a jwt token in the response
  //      if (user && user.token) {
  //        // store user details and jwt token in local storage to keep user logged in between page refreshes
  //        localStorage.setItem('currentUser', JSON.stringify(user));
  //        this.currentUserSubject.next(user);
  //      }

  //      return user;
  //    }));
  //}

  login(username: string, password: string) {

    //var data = "username=" + username + "&password=" + password + "&grant_type=password";
    //var reqHeader = new HttpHeaders({ 'Content-Type': 'application/x-www-urlencoded', 'No-Auth': 'True' });
    let gUser: User;
    let data1 = {
      "UserName": username,
      "Password": password
    };
    return this.http.post(ROOT_URL + 'api/Token/GetToken', data1);
    //return this.http.post(ROOT_URL + '/api/Token/GetToken', data1);
  }

  loginSSO() {
    return this.http.post(ROOT_URL + 'api/Token/GetTokenSSO', null);
    //return this.http.post(ROOT_URL + '/api/Token/GetToken', data1);
  }
  setTempData(userToken: string, userModel: User) {
    userModel.token = userToken;
    localStorage.setItem('userToken', userToken);
    localStorage.setItem('currentUser', JSON.stringify(userModel));
    this.currentUserSubject.next(userModel);
  }

  LogInOkkay(value) {
    var data = "username=" + value.username + "&password=" + value.password + "&grant_type=password";
    var reqHeader = new HttpHeaders({ 'Content-Type': 'application/x-www-urlencoded', 'No-Auth': 'True' });
    return this.http.post(ROOT_URL + '/token', data, { headers: reqHeader });
  }


  logout() {
    // remove user from local storage to log user out
    localStorage.removeItem('currentUser');
    localStorage.removeItem('userToken');
    this.currentUserSubject.next(null);
  }


}
