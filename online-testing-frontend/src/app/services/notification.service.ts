import { Injectable } from '@angular/core';
import {Subject} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class NotificationService {
  message$ = new Subject<string>()
  isError$ = new Subject<boolean>()
  isModal$ = new Subject<boolean>()

  constructor() { }

  showSuccess(message: string, isModal = false): void {
    this.show(message, false, isModal)
  }

  showError(message: string, isModal = false): void {
    this.show(message, true, isModal)
  }

  clear() {
    this.show('', false, false)
  }

  private show(message:string, isError: boolean, isModal: boolean) {
    this.isError$.next(isError);
    this.isModal$.next(isModal);
    this.message$.next(message);
  }
}
