import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'filter'
})
export class FilterPipe implements PipeTransform {

  transform(value: any[], filterString: string, recipeName: string): any[] {
    const resultArray = [];
    if(value.length === 0 || filterString ==='' || recipeName === '') {
      return value;
    }
    for (const item of value){
      if (item[recipeName] === filterString) {
        resultArray.push(item);
      }
    }
    return resultArray;
  }

}
