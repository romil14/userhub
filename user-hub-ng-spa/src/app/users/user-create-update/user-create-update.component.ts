import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { RepositoryService } from 'src/app/shared/services/repository.service';
import { User } from 'src/app/_interfaces/user.model';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-user-create-update',
  templateUrl: './user-create-update.component.html',
  styleUrls: ['./user-create-update.component.css']
})
export class UserCreateUpdateComponent implements OnInit {
  public errorMessage: string = '';
  public userForm: any;
  public user: any;
  constructor(private repository: RepositoryService, private router: Router, private datePipe: DatePipe, private toastr: ToastrService, private activeRoute: ActivatedRoute) { }


  ngOnInit(): void {
    this.userForm = new FormGroup({
      name: new FormControl('', [Validators.required, Validators.maxLength(50)]),
      dateOfBirth: new FormControl('', [Validators.required]),
      email: new FormControl('', [Validators.required, Validators.email, Validators.maxLength(50)]),
      gender: new FormControl('M', [Validators.required]),
      password: new FormControl('', [Validators.required, Validators.minLength(6), Validators.maxLength(50)]),  
      userName: new FormControl('', [Validators.required, Validators.maxLength(20)]),
      userDetailsId: new FormControl(0)
    });

    let id = this.activeRoute.snapshot.params['id'];
    if(id && id > 0){
      this.fnGetUserDetails(id);
    }
  }

  fnGetUserDetails = (id: number) =>{
    
    let apiUrl = `GetUserById/${id}`;

    this.repository.getData(apiUrl)
    .subscribe((res: any) =>{
     
      if(res && res.statusCode == 1){
        this.user = res.responseInfo;
        this.user.dateOfBirth = this.datePipe.transform(this.user.dateOfBirth, 'yyyy-MM-dd')
        this.userForm.patchValue(this.user);
      }      
    })
  }

  public validateControl = (controlName: string) => {
    if (this.userForm && this.userForm.controls[controlName].invalid && this.userForm.controls[controlName].touched)
      return true;
    return false;
  }

  public hasError = (controlName: string, errorName: string) => {
    if (this.userForm && this.userForm.controls[controlName].hasError(errorName))
      return true;
    return false;
  }

  public executeDatePicker = (event: any) => {
    if(this.userForm){
      this.userForm.patchValue({ 'dateOfBirth': event });
    }
    
  }

  public createUser = (userFormValue: any) => {
    if (this.userForm && this.userForm.valid) {
      this.executeUserCreation(userFormValue);
    }
  }

  private executeUserCreation = (userFormValue: any) => {
  
  
    this.errorMessage = "";
    var selectedDate = this.datePipe.transform(userFormValue.dateOfBirth, 'yyyy-MM-dd') ;
    const user: User = {
      name: userFormValue.name,
      dateOfBirth: selectedDate ? selectedDate : '12-07-21',
      email: userFormValue.email,
      gender: userFormValue.gender,
      password: userFormValue.password,
      status:1,
      updatedOn: (new Date()),
      userName: userFormValue.userName,
      userDetailsId: userFormValue.userDetailsId
    }
    const apiUrl = userFormValue.userDetailsId > 0 ? 'UpdateUser' : 'CreateUser';
    this.repository.create(apiUrl, user)
      .subscribe((res : any) => {
      
        if(res && res.statusCode == 1){
          this.toastr.success("Success");
          setTimeout(() => {
            this.redirectToUserList();
          }, 200);  
        }
        else if(res && res.statusCode == 2){
          if(res.errorInfo && res.errorInfo.length > 0 && res.errorInfo[0].errorCode == "EI02"){
            //this.toastr.error(res.errorInfo[0].message);
            this.errorMessage = res.errorInfo[0].message;
          }else{
            this.toastr.error("Something went wrong, please try again.");
          }
         
        }        
      },
      (error => {
        
      })
    )
  }
  public redirectToUserList(){
    this.router.navigate(['/users/list']);
  }

}
