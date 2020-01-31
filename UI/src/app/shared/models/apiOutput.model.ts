export class ApiOutput<T> {
  result: T;
  error: string;
  statusCode: number;

  constructor(init?: Partial<ApiOutput<T>>) {
    Object.assign(this, init);
  }
}
