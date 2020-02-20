import { Component, OnInit } from '@angular/core';
import { ContactsClient, ContactDto } from '../../api/api.phone.client';
import { ActivatedRoute } from '@angular/router';
import { Observable, throwError as _observableThrow, of as _observableOf } from 'rxjs';
import { ItemActionBase } from './../generics/item-action-base';

@Component({
  selector: 'app-contact-new',
  templateUrl: './contact-new.component.html',
  providers: [ContactsClient]
})

export class ContactNewComponent extends ItemActionBase<ContactDto> implements OnInit {

  /** Call API for save */
  public actionApi(): Observable<ContactDto> {
    return this.api.create(this.item);
  }

  /**
   * Call API to get data
   * @param id
   */
  public loadApi(id: string): Observable<ContactDto> {

    this.item = new ContactDto();
    return _observableOf<ContactDto>(this.item);
  }

  /**
   * Constructor with route and api client injection
   * @param api
   * @param route
   */
  constructor(api: ContactsClient, route: ActivatedRoute) {
    super(api, route);
  }

}
