# ParaBank Open Page Test Plan

## Objective

Verify that the ParaBank home page opens successfully in Chrome and is ready for follow-up UI automation.

## Current Automated Coverage

| Test | Purpose | Main Checks |
| --- | --- | --- |
| `HomePage_OpensSuccessfully` | Confirms the home page can be opened from the configured URL. | Browser navigates to ParaBank, page load completes, login panel is visible, URL contains `/parabank/`, title contains `ParaBank`, login heading contains `Customer Login`. |
| `RegisterPage_OpensFromHomePage` | Confirms the Register link can be opened from the home page. | Browser clicks the `Register` link, registration form is visible, URL contains `register.htm`, page heading contains `Signing up is easy!`. |
| `LoanApplication_OpensAfterLogin` | Planned loan scenario. | Ignored until valid test credentials are available. |

## Test Data

| Item | Value |
| --- | --- |
| Browser | Chrome |
| URL | `https://parabank.parasoft.com/parabank/index.htm` |
| Framework | MSTest with Selenium WebDriver |

## Scenario Organization

| Folder/File | Purpose |
| --- | --- |
| `Tests/OpenPageTests.cs` | Smoke checks for opening the site. |
| `Tests/RegisterTests.cs` | Registration scenarios. |
| `Tests/LoanTests.cs` | Loan application scenarios. |
| `Workflows/ParaBankWorkflow.cs` | Reusable Selenium actions used by scenarios. |
| `Tests/BaseTest.cs` | Shared browser setup and cleanup. |

## Test Run Examples

| Run | Filter |
| --- | --- |
| Smoke only | `TestCategory=Smoke` |
| Register only | `TestCategory=Register` |
| Loan only | `TestCategory=Loan` |
| Smoke + Register | `TestCategory=Smoke|TestCategory=Register` |

## Preconditions

- Chrome is installed.
- The ChromeDriver package version is compatible with the installed Chrome version.
- The machine can reach `https://parabank.parasoft.com`.
- NuGet packages have been restored.

## Manual Test Steps

1. Open Chrome.
2. Navigate to `https://parabank.parasoft.com/parabank/index.htm`.
3. Confirm the page loads without browser/network errors.
4. Confirm the ParaBank page title is visible.
5. Confirm the customer login panel is visible.

## Expected Result

The ParaBank home page loads successfully, the browser remains on a ParaBank URL, and the customer login area is displayed.

## Recommended Next Automated Tests

1. Verify failed login shows a validation/error message.
2. Verify required registration fields show validation messages.
3. Verify successful registration with unique user data.
4. Verify navigation links in the public menu open the expected pages.
5. Add a base test class when more tests are introduced, so browser setup and teardown are shared.
