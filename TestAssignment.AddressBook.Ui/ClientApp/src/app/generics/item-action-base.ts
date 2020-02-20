import { ContactsClient, ModelErrorDto } from '../../api/api.phone.client';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { ViewChild } from '@angular/core';
import { ModalWindowComponent } from '../modal-window/modal-window.component';

export abstract class ItemActionBase<T> {

  public item: T;

  @ViewChild('modal', { static: false }) modal: ModalWindowComponent;

  public error: ModelErrorDto;

  public status: ItemActionStatus = new ItemActionStatus();

  public serverErrorTitle: string;

  public serverErrorResponse: string;

  /**
   * Load method
   * @param id
   */
  abstract loadApi(id: string): Observable<T>;

  /** API action (delete, update, insert) definition */
  abstract actionApi(): Observable<T>;

  /**
   * Handle api get error
   * @param err
   */
  protected handleApiGetError(err: any) {
    this.status.loading = false;
    this.serverErrorTitle = err.message;
    this.serverErrorResponse = err.response;
    if (err.status != 404) {
      this.modal.open();
    }
  }

  /**
   * Handle error
   * @param err
   */
  protected handleApiActionError(err: any) {
    this.status.loading = false;
    if (err instanceof ModelErrorDto) {
      this.error = err;
      this.status.actionError = true;
    } else {
      this.serverErrorTitle = err.message;
      this.serverErrorResponse = err.response;
      this.modal.open();
    }
  }

  /**
   * Handle api response
   * @param data
   */
  protected handleApiGetResponse(data: T) {
    this.status.loading = false;
    this.item = data;
  }

  /**
   * Handle api action response
   * @param data
   */
  protected handleApiActionResponse(data: T) {
    this.status.loading = false;
    this.status.actionSuccess = true;
    this.item = data;
  }

  /**
   * Load item
   * @param id
   */
  public load(id: string) {

    // clear current item
    this.item = undefined;

    // set loading 
    this.status.loading = true;

    // execute load
    this.loadApi(id).subscribe(data => this.handleApiGetResponse(data), err => this.handleApiGetError(err));
  }

  /** Action execution */
  protected action() {

    // do nothing if item not binded (this should actually not happen)
    if (this.item == undefined) {
      return;
    }

    // update ui
    this.status.loading = true;
    this.error = undefined;
    this.status.actionSuccess = false;
    this.status.actionError = false;

    // execute save
    this.actionApi().subscribe(data => this.handleApiActionResponse(data), err => this.handleApiActionError(err));
  }

  /**
   * Clear notifications for field
   * @param name
   */
  public clearNotifications(name: string): void {
    this.status.actionSuccess = false;
    if (!!this.error && !!this.error.errors) {
      delete this.error.errors[name];
      this.status.actionError = false;
    }
  }

  /**
   * Constructor with route and api client injection
   * @param api
   * @param route
   */
  constructor(protected api: ContactsClient, protected route: ActivatedRoute) { }
  
  /** Component init */
  ngOnInit() {
    let id: string = this.route.snapshot.params['id'];
    this.load(id);
  }

}

export class ItemActionStatus {

  public loading: boolean = true;

  public actionSuccess: boolean = false;

  public actionError: boolean = false;
}
