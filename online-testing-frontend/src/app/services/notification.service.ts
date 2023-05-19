import { Injectable } from '@angular/core';
import {Subject} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class NotificationService {
  message$ = new Subject<string>()
  isError$ = new Subject<boolean>()

  constructor() { }

  showSuccess(message: string): void {
    this.show(message, false)
  }

  showError(message: string): void {
    this.show(message, true)
  }

  clear() {
    this.show('', false)
  }

  private show(message:string, isError: boolean) {
    this.isError$.next(isError);
    this.message$.next(message);
  }
}
