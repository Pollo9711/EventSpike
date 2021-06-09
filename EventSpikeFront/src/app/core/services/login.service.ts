import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserLight } from 'src/app/models/UserLight';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  url: string = "https://localhost:5001/api/User";

  constructor(private api: ApiService) { }

  post(obj: UserLight): any {
    return new Observable( subscriber => {
      this.api.post<UserLight>(this.url, obj)
        .subscribe( response => {
          subscriber.next(response);
        },
        (error) => {
          subscriber.error(error);
        },
        () => {} 
        );
    });
  }

}
