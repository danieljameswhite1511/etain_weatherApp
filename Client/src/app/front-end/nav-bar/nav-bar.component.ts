import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AccountService } from 'src/app/account/account.service';
import { IUser } from 'src/app/shared/models/user';
import { environment } from 'src/environments/environment';


@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})

export class NavBarComponent implements OnInit {
  
  currentUser$: Observable<IUser>;
  baseUrl = environment.apiUrl;
  menu: [];
  menuName: '';
  menuItems: [];

  constructor(private http: HttpClient, private accountService: AccountService, private router: Router) { }
  
  ngOnInit(): void {

    this.currentUser$ = this.accountService.currentUser$;

    this.http.get(this.baseUrl + 'menus?name=Main').subscribe((menu: any)=> {
      
      this.menuName = menu[0].name;
      this.menuItems = menu[0].menuItems;
      console.log(this.menuItems)
      return this.menuItems;

    },error => {
      
      console.log(error)

    });
  }

  logOut(){
    this.accountService.logOut();
    this.router.navigateByUrl('/');
  }

}
