import { Component, OnInit } from '@angular/core';
import { RepositoryService } from 'src/app/shared/services/repository.service';
import { User } from 'src/app/_interfaces/user.model';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-users-list',
  templateUrl: './users-list.component.html',
  styleUrls: ['./users-list.component.css']
})
export class UsersListComponent implements OnInit {

  public users: User[] | undefined;
  constructor(private repository: RepositoryService, private router: Router, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.fnGetAllUsers();
  }

  public fnGetAllUsers = () =>{
    let apiAddress = "GetAllUsers";
    this.repository.getData(apiAddress)
    .subscribe((res: any) =>{     
      if(res && res.statusCode == 1){    
        this.users = res.responseInfo;
      }
     
    })
  }

  public fnGetUserDetails = (id: number) =>{
    const detailsUrl = `/users/details/${id}`;
    this.router.navigate([detailsUrl]);
  }

  public fnGoToCreateUser = () =>{    
    const createUrl = `/users/create-update/0`;
    this.router.navigate([createUrl])
  }

  public fnGoToUpdateUser = (id: number) =>{    
    const updateUrl = `/users/create-update/${id}`;
    this.router.navigate([updateUrl])
  }

  public fnDeleteUser = (id: number) =>{    
    const deleteUrl: string = `DeleteUser/${id}`;
    this.repository.delete(deleteUrl)
    .subscribe(res => {
      this.toastr.success("Success");
      setTimeout(() => {
        this.fnGetAllUsers();
      }, 200);
    },
    (error) => {
      this.toastr.error("Something went wrong, please try again.");
    })
  }
}
