import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppsettingComponent } from './admin/appsetting/appsetting.component';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'admin/appsetting', component: AppsettingComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
