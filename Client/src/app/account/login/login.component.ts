import { Component, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators, FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AccountService } from '../account.service';
import { HttpParams } from '@angular/common/http';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

 public loginForm: FormGroup = new FormGroup({});
 route: any;

  constructor(private accountService: AccountService, private router: Router, private activatedRoute: ActivatedRoute, private formBuilder: FormBuilder) { }

  ngOnInit(): void {

    this.createLoginForm();

    this.activatedRoute.paramMap.subscribe(route => {
      this.route=route;
      console.log(this.route.params);
    });

  }

  createLoginForm(){
    this.loginForm = this.formBuilder.group({
      email: new FormControl('', Validators.required),
      //email: new FormControl('',[Validators.required, Validators.pattern('^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$')]),
      password: new FormControl('', Validators.required)
    })
  }

  onSubmit(){
    console.log(this.loginForm.value);
    this.accountService.login(this.loginForm.value).subscribe(() => {
    this.router.navigate(['/weather']);
      console.log('User logged in');
    }, error => {
      console.log(error);

    });
  }
}
