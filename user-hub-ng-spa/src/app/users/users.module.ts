import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UsersListComponent } from './users-list/users-list.component';
import { RouterModule } from '@angular/router';
import { UserDetailsComponent } from './user-details/user-details.component';



@NgModule({
  declarations: [
    UsersListComponent,
    UserDetailsComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild([
      {path: 'list', component: UsersListComponent},
      {path: 'details/:id', component: UserDetailsComponent}
    ])
  ]
})
export class UsersModule { }
