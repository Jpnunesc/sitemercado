import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { Injectable } from '@angular/core';
import { tap } from 'rxjs/internal/operators/tap';
import { HttpEvent, HttpInterceptor, HttpRequest, HttpHandler } from '@angular/common/http';
import { AuthenticationService } from './authentication.service';

@Injectable({ providedIn: 'root' })
export class AuthInterceptor implements HttpInterceptor {
    constructor(private authenticationService: AuthenticationService) { }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        const currentUser = this.authenticationService.currentUserValue;
        if (currentUser && currentUser.authdata) {
            request = request.clone({
                setHeaders: { 
                    Authorization: `Basic ${currentUser.authdata}`
                }
            });
        }
        return next.handle(request);
    }
}
