import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DatepickerDirective } from './directives/datepicker.directive';



@NgModule({
  declarations: [ 
    DatepickerDirective
  ],
  exports:[  
    DatepickerDirective
  ],
  imports: [
    CommonModule
  ]
})
export class SharedModule { }
