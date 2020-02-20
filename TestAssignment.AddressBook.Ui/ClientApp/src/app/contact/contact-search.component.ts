import { Component, OnInit, ViewChild } from '@angular/core';
import { ContactsClient, PagedListDtoOfContactDto, ModelErrorDto } from '../../api/api.phone.client';
import { Observable } from 'rxjs';
import { ModalWindowComponent } from '../modal-window/modal-window.component';

@Component({
  selector: 'app-contact-search',
  templateUrl: './contact-search.component.html',
  providers: [ContactsClient]
})
export class ContactSearchComponent implements OnInit {

  @ViewChild('modal', { static: false }) modal: ModalWindowComponent;

  private api: ContactsClient;

  public data: PagedListDtoOfContactDto;

  public filter: ContactFilterDto;

  public filterError: ModelErrorDto;

  private pageRecords: number;

  public loading: boolean = false;

  public serverErrorTitle: string;

  public serverErrorResponse: string;

  constructor(api: ContactsClient) {
    this.api = api;
    this.filter = new ContactFilterDto();
    this.pageRecords = 10;
  }

  /** get count of current items */
  public itemsCount(): number {
    return this.isDataLoaded() ? this.data.list.length : 0;
  }

  /** Filter error  */
  public isFilterError(): boolean {
    return this.filterError instanceof ModelErrorDto ? true : false;
  }

  /** Data loaded status */
  public isDataLoaded(): boolean {
    return (!!this.data && !!this.data.list);
  }

  /**
   * Search data
   * @param offset
   */
  public search(offset: number = 0): Observable<PagedListDtoOfContactDto> {

    // reset data
    this.data = undefined;
    this.filterError = undefined;
    this.loading = true;
    this.serverErrorTitle = undefined;
    this.serverErrorResponse = undefined;

    // execute search
    var obs = this.api.search(this.filter.firstName, this.filter.lastName, this.filter.phoneNumber, this.filter.address, offset, this.pageRecords);
    obs.subscribe(
      data => {
        this.data = data;
        this.loading = false;
      },
      err => {
        if (err instanceof ModelErrorDto) {
          this.filterError = err;
        } else {
          this.serverErrorTitle = err.message;
          this.serverErrorResponse = err.response;
          this.modal.open();
        }
        this.loading = false;
      });

    // return 
    return obs;
  }

  /** Component init */
  ngOnInit() {
    this.search(0);
  }
}

/** Filter */
export class ContactFilterDto {
  firstName: string = "";
  lastName: string = "";
  phoneNumber: string = "";
  address: string = "";
}
