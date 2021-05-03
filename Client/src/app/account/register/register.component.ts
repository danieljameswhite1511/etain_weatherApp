import { variable } from '@angular/compiler/src/output/output_ast';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';
import { AccountService } from '../account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  registerForm: FormGroup = new FormGroup({});
  errors: string[];

  constructor(private formBuilder: FormBuilder, private accountService: AccountService, private router: Router) { }

  ngOnInit(): void {
    this.createFormGroup();
  }

  createFormGroup(){

    this.registerForm = this.formBuilder.group({
      displayName: new FormControl('', Validators.required),
      email: new FormControl('', Validators.required),
      //email:  new FormControl('', [Validators.required, Validators.pattern('^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$')]),
      password: new FormControl('', [Validators.required])
    });

  }

  onSubmit(){
    console.log(this.registerForm.value);
    this.accountService.register(this.registerForm.value).subscribe(response => {

      this.router.navigateByUrl('/');
    }, error => {

      this.errors = error.error.errors;
      console.log(this.errors);
    });
  }

}
