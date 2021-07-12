import { NgModule } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';
import { UsersListComponent } from './users-list/users-list.component';
import { RouterModule } from '@angular/router';
import { UserDetailsComponent } from './user-details/user-details.component';
import { SharedModule } from '../shared/shared.module';
import { UserCreateUpdateComponent } from './user-create-update/user-create-update.component';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    UsersListComponent,
    UserDetailsComponent,
    UserCreateUpdateComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    ReactiveFormsModule,
    RouterModule.forChild([
      {path: 'list', component: UsersListComponent},
      {path: 'details/:id', component: UserDetailsComponent},
      {path: 'create-update/:id', component: UserCreateUpdateComponent}
    ])
  ],
  providers: [
    DatePipe   
  ]
})
export class UsersModule { }
