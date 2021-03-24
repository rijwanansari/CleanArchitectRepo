import { Component, OnInit } from '@angular/core';
import { Appsetting } from '../../_model/admin/appetting';
import Swal from 'sweetalert2';
import { AppsettingService } from '../../_service/master/appsetting.service';
import { Observable } from 'rxjs';


@Component({
  selector: 'app-appsetting',
  templateUrl: './appsetting.component.html',
  styleUrls: ['./appsetting.component.scss']
})
export class AppsettingComponent implements OnInit {
  public appsetting: Appsetting = new Appsetting();
  appsettings: any;
  constructor(private appsettingService: AppsettingService) { }

  ngOnInit(): void {
    this.appsetting.id = 0;
    this.appsetting.isDelete = false;
    this.GetAllAppSetting();
  }

  OnSubmit() {
    try {
      this.appsettingService.UpsertAppSetting(this.appsetting).subscribe((data: any) => {
        if (data.success) {
          Swal.fire(
            'Saved!',
            'Saved Successfully!',
            'success'
          );
          this.GetAllAppSetting();
        } else {
          Swal.fire('Oops...', 'Something went wrong! Method: UpsertAppSetting(), Component: AdminUser', 'error');
          (error: any) => {
            console.log(error);
          }
        }
      });
    } catch (e) {
      console.log(e);
      Swal.fire('Oops...', 'Something went wrong!, Please contact your administrator', 'error');
    }
    console.log(this.appsetting);
    Swal.fire('Hello Angular');
  }

  GetAllAppSetting() {
    this.appsettingService.GetAllAppSetting().subscribe((data: any) => {
      if (data.success) {
        this.appsettings = data.output;
        //console.log(data);
        console.log(this.appsettings);
      } else {
        Swal.fire('Oops...', 'Something went wrong!, Please contact your administrator', 'error');
        (error: any) => {
          console.log(error);
        }
      }
    });
  }
}
