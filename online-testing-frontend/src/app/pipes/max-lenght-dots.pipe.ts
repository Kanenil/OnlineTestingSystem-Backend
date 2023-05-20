import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'maxLenghtDots'
})
export class MaxLenghtDotsPipe implements PipeTransform {

  transform(value: string | undefined,maxLenght: number): string {

    if(value)
      return value.length > maxLenght?`${value.slice(0, maxLenght)}...`: value;

    return '';
  }

}
