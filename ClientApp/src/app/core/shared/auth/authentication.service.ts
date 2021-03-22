import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment.prod';


@Injectable({ providedIn: 'root' })
export class AuthenticationService {
    private currentUserSubject: BehaviorSubject<any>;
    public currentUser: Observable<any>;

    constructor(private http: HttpClient) {
        this.currentUserSubject = new BehaviorSubject<any>(JSON.parse(localStorage.getItem('currentUser')));
        this.currentUser = this.currentUserSubject.asObservable();
    }

    public get currentUserValue(): any {
        return this.currentUserSubject.value;
    }

    login(username: string, password: string) {
        return this.http.post<any>(`${environment.URL}/Users/authenticate`, { username, password })
            .pipe(map(data => {
                if (data.success) {
                    data.authdata = btoa(username + ':' + password);
                    localStorage.setItem('currentUser', JSON.stringify(data));
                    this.currentUserSubject.next(data);
                    return data;
                } else {
                    return data;
                }
            }));
    }
    logout() {
        localStorage.removeItem('currentUser');
        this.currentUserSubject.next(null);
    }
}