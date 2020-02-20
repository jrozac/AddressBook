import { Component, OnInit } from '@angular/core';
import { ContactsClient, ContactDto } from '../../api/api.phone.client';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { ItemActionBase } from './../generics/item-action-base';

@Component({
  selector: 'app-contact-edit',
  templateUrl: './contact-edit.component.html',
  providers: [ContactsClient]
})

export class ContactEditComponent extends ItemActionBase<ContactDto> implements OnInit  {

  /** Call API for save */
  public actionApi(): Observable<ContactDto> {
    return this.api.update(this.item);
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

