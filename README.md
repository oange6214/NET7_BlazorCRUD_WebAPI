# Global Exception Handling in ASP.NET Core Web API

## 簡介
此專案演示了如何在 ASP.NET Core Web API 應用程式中實現全域異常處理（Global Exception Handling）。全域異常處理允許開發者在整個應用程式中統一捕獲和處理異常，包括未處理異常、HTTP 錯誤狀態碼的產生以及自定義錯誤訊息的產生等。

## 使用情境
- **統一錯誤回應**：實現 API 異常情況的一致回應。
- **紀錄異常**：在全域異常處理中紀錄所有異常，方便 Debug 和 Monitor。
- **安全性**：隱藏應用程式中的具體錯誤詳細資訊，防止資訊外洩。
- **自訂錯誤處理**：為不同異常定制錯誤處理邏輯。

## 優缺點
- **優點**：
  1. **一致性**：確保 API 處理各種異常情況的一致性。
  2. **簡化代碼**：將異常處理邏輯從控制器中分離，簡化控制器代碼。
  3. **安全性**：隱藏錯誤詳細資訊，減少安全風險。
- **缺點**：
  1. **複雜性**：實施全域異常處理可能增加程式碼和配置的複雜性。
  2. **過度抽象**：可能導致程式碼過度抽象，難以理解錯誤處理。
  3. **性能開銷**：大量異常處理可能對性能造成開銷。

## 專案設置
### 建立專案
- 創建名為 `GrobalErrorApp` 的 ASP.NET Core Web API 專案。

### 安裝 NuGet 套件
```bash
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
dotnet add package Microsoft.EntityFrameworkCore.Tools
```

## 建立 Model
- 在 `Models` 目錄下建立 `Driver.cs` 以定義 `Driver` 實體。

## 設置 DbContext
- 在 `src/Data` 目錄下建立 `AppDbContext.cs`，並配置 `DbContext`。

## Docker Compose 設置
- 建立 `docker-compose.yml` 文件以配置和運行 PostgreSQL 容器。

## 更新 Program.cs
- 配置應用程式以使用 `DbContext` 和全域異常處理。

## 實作全域異常處理
### 建立異常類型
- 在 `Exceptions` 目錄中定義應用程式可能拋出的異常類型。

### 建立中間件
- 實現 `GlobalExceptionHandlingMiddleware` 來捕獲和處理異常。

### 配置中間件
- 通過擴展方法 `AddGlobalErrorHandler` 在 `Program.cs` 中配置全域異常處理中間件。

## 測試
- 確保資料庫服務正在運行。
- 運行 Web API 並使用 Swagger 進行端點測試。

## 結論
- 通過此專案，我們展示了如何在 ASP.NET Core Web API 中實施全域異常
