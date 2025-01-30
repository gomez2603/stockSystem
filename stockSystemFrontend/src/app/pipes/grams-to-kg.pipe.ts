import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'gramsToKg'
})
export class GramsToKgPipe implements PipeTransform {
  transform(value: number): string {
    if (!value) return '0 kg';
    return (value / 1000).toFixed(2) + ' kg';
  }
}