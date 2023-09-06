import { ListService, PagedResultDto } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CustomerService, CustomerDto } from '@proxy/customers';
import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.scss'],
  providers: [ListService],
})
export class CustomerComponent implements OnInit {
  customer = { items: [], totalCount: 0 } as PagedResultDto<CustomerDto>;

  form: FormGroup;

  isModalOpen = false;

  selectedCustomer = {} as CustomerDto; // declare selectedCustomer

  constructor(public readonly list: ListService, private customerService: CustomerService, private fb: FormBuilder, private confirmation: ConfirmationService) {}

  ngOnInit() {
    const customerStreamCreator = (query) => this.customerService.getList(query);

    this.list.hookToQuery(customerStreamCreator).subscribe((response) => {
      this.customer = response;
    });
  }

  editCustomer(id: string) {
    this.customerService.get(id).subscribe((customer) => {
      console.log(customer);
      this.selectedCustomer = customer;
      this.buildForm();
      this.isModalOpen = true;
    });
  }

  delete(id: string) {
    this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure').subscribe((status) => {
        if (status === Confirmation.Status.confirm) {
            this.customerService.delete(id).subscribe(() => this.list.get());
        }
    });
}


  createCustomer() {
    this.buildForm();
    this.isModalOpen = true;
  }

  save() {
    if (this.form.invalid) {
        return;
    }

    const request = this.selectedCustomer.id
        ? this.customerService.update(this.selectedCustomer.id, this.form.value)
        : this.customerService.create(this.form.value);

    request.subscribe(() => {
        this.isModalOpen = false;
        this.form.reset();
        this.list.get();
    });
}

  

  buildForm() {
    this.form = this.fb.group({
      customerName: ['', Validators.required],
      riskLimit: [null, Validators.required],
      billingAddress: ['', Validators.required], // varsayılan olarak string alındı.
      tenantId: [null] // tenantId için özel bir validator olmadığı varsayıldı.
    });
  }
  
}
