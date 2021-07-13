import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RepositoryService } from 'src/app/shared/services/repository.service';
import { User } from 'src/app/_interfaces/user.model';

@Component({
  selector: 'app-user-details',
  templateUrl: './user-details.component.html',
  styleUrls: ['./user-details.component.css']
})
export class UserDetailsComponent implements OnInit {
  public user: User | undefined;
  public errorMessage: string = '';

  constructor(private repository: RepositoryService, private router: Router, 
              private activeRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.fnGetUserDetails();
  }

  fnGetUserDetails = () =>{
    let id = this.activeRoute.snapshot.params['id'];
    let apiUrl = `GetUserById/${id}`;

    this.repository.getData(apiUrl)
    .subscribe((res: any) =>{
      if(res && res.statusCode == 1){
        this.user = res.responseInfo;
      }      
    })
  }

  fnRedirectToUserList(){
    this.router.navigate(['/users/list']);
  }

}
