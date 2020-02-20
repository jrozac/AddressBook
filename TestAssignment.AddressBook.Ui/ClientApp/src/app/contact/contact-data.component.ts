import { Component, Input } from '@angular/core';
import { ContactDto } from '../../api/api.phone.client';

@Component({
  selector: 'app-contact-data',
  templateUrl: './contact-data.component.html',
})
export class ContactDataComponent {

  @Input()
  public item: ContactDto;

}
