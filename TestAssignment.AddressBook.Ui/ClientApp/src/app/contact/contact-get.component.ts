import { Component, OnInit } from '@angular/core';
import { ContactsClient, ContactDto } from '../../api/api.phone.client';
import { ActivatedRoute } from '@angular/router';
import { ItemActionBase } from '../generics/item-action-base';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-contact-get',
  templateUrl: './contact-get.component.html',
  providers: [ContactsClient]
})
export class ContactGetComponent extends ItemActionBase<ContactDto> implements OnInit {

  /** Call API for save */
  public actionApi(): Observable<ContactDto> {
    return undefined;
  }

  /**
   * Call API to get data
   * @param id
   */
  public loadApi(id: string): Observable<ContactDto> {
    return this.api.get(id);
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
