import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ROOT_URL } from '../../_model/config';

@Injectable({
  providedIn: 'root'
})
export class AppsettingService {

  constructor(private http: HttpClient) { }

  UpsertAppSetting(adminUser: any) {
    return this.http.post(ROOT_URL + 'api/Master/UpsertAppSetting', adminUser);
  }

  GetAllAppSetting() {
    //console.log(this.currentUserSubject.value);
    return this.http.get(ROOT_URL + 'api/Master/GetAllAppSetting');
  }
}
