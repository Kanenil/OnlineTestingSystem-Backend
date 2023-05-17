import { Injectable } from '@angular/core';
import {Subject} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class ErrorService {
  error$ = new Subject<string>()

  handle(messsage: string) {
    this.error$.next(messsage)
  }

  clear() {
    this.error$.next('')
  }
}
