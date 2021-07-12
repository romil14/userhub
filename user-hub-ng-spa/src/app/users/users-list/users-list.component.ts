import { Component, OnInit } from '@angular/core';
import { RepositoryService } from 'src/app/shared/services/repository.service';
import { User } from 'src/app/_interfaces/user.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-users-list',
  templateUrl: './users-list.component.html',
  styleUrls: ['./users-list.component.css']
})
export class UsersListComponent implements OnInit {

  public users: User[] | undefined;
  constructor(private repository: RepositoryService, private router: Router) { }

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

}
