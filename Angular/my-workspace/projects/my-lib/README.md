# Angular API Error Handler with SweetAlert

## Overview
This package helps you manage your API errors elegantly by showing them through SweetAlert toast notifications. You no longer have to handle API errors manually in each service or component. Just inject our `ErrorService`, and you're good to go!

## Installation

```bash
npm install --save angular-error-service
```

## Usage

### Step 1: Import the ErrorModule

First, import `ErrorModule` in your Angular application module.

```typescript
import { ErrorModule } from 'angular-error-service';

@NgModule({
  ...
  imports: [ErrorModule],
  ...
})
export class AppModule { }
```

### Step 2: Inject `ErrorService` into your Component or Service

Inject `ErrorService` into your Angular component or service where you handle API requests.

```typescript
import { ErrorService } from 'your-package-name';

constructor(private errorService: ErrorService) {}
```

### Step 3: Handle Errors

Use `errorHandler` method to handle your API errors.

```typescript
this.http.get('your-api-endpoint').subscribe(
  data => {
    // handle data
  },
  (error: HttpErrorResponse) => {
    this.errorService.errorHandler(error);
  }
);
```

## Supported Error Types

- `500`: Internal Server Error
- `403`: Forbidden
- `415`: Unsupported Media Type
- `404`: Not Found

## Customization

You can customize the toast by providing title and icon to `callToast` method.

```typescript
this.swal.callToast('Your Content', 'Your Title', 'success');
```

## License

MIT
