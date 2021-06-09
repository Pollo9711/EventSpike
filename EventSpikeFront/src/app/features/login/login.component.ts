
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { LoginService } from 'src/app/core/services/login.service';
import { UserLight } from '../../models/UserLight';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;
  userLight: UserLight;

  constructor(private loginService: LoginService) { 
    this.loginForm = new FormGroup({

      email: new FormControl(),
      password: new FormControl()

    });
  }

  ngOnInit(): void {
  }

  loginUser(): void {

    this.userLight = this.loginForm.value as UserLight;

    this.loginService.post(this.userLight)
      .subscribe( (response: any) => {

      },
      (error: any) => {
        console.log(error);
      },
      () => {}
    ); 
  }

  printUserData(): void {
    console.log(this.loginForm.value as UserLight)
  }

}
