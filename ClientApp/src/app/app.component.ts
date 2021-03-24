import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthenticationService } from './core/shared/auth/authentication.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit  {
  currentUser: any;

  constructor(
      private router: Router,
      private activeRoute: ActivatedRoute,
      private authenticationService: AuthenticationService
  ) {
      this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
  }
  ngOnInit() {
    this.authenticationService.logout();
}
  logout() {
      this.authenticationService.logout();
      this.router.navigate(['/login']);
  }
}
