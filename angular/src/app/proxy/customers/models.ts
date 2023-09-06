import type { AuditedEntityDto } from '@abp/ng.core';

export interface CreateUpdateCustomerDto {
  customerName: string;
  riskLimit: number;
  billingAddress: string;
}

export interface CustomerDto extends AuditedEntityDto<string> {
  customerName?: string;
  riskLimit: number;
  billingAddress?: string;
  tenantId?: string;
}


