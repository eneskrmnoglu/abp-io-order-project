import type { AuditedEntityDto } from '@abp/ng.core';

export interface CustomerDto extends AuditedEntityDto<string> {
  customerName?: string;
  riskLimit: number;
  billingAddress?: string;
  tenantId?: string;
}
