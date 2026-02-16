---
goal: Upgrade Chirper API from .NET 8.0 to .NET 10.0
version: 1.0
date_created: 2026-02-16
last_updated: 2026-02-16
owner: Development Team
status: 'Planned'
tags: ['upgrade', 'dotnet10', 'framework', 'migration', 'minimal-api']
---

# .NET 10.0 Upgrade Implementation Plan

![Status: Planned](https://img.shields.io/badge/status-Planned-blue)

This plan outlines the systematic upgrade of the Chirper social media API from .NET 8.0 to .NET 10.0. The project uses ASP.NET Core Minimal APIs with Vertical Slice Architecture, Entity Framework Core, JWT authentication, and follows modern C# practices.

## 1. Requirements & Constraints

### Requirements

- **REQ-001**: Upgrade project from .NET 8.0 to .NET 10.0 LTS
- **REQ-002**: Maintain backward compatibility with existing API contracts
- **REQ-003**: Update all NuGet packages to .NET 10-compatible versions
- **REQ-004**: Preserve existing functionality without breaking changes
- **REQ-005**: Maintain current architecture (Vertical Slice Architecture)
- **REQ-006**: Ensure all tests pass after upgrade
- **REQ-007**: Update CI/CD pipelines for .NET 10 SDK
- **REQ-008**: Update Docker configurations for .NET 10 runtime

### Security Requirements

- **SEC-001**: Verify JWT authentication continues working with .NET 10
- **SEC-002**: Review and apply .NET 10 security improvements
- **SEC-003**: Update authentication middleware configuration if needed
- **SEC-004**: Validate HTTPS/TLS configuration with .NET 10

### Performance Requirements

- **PERF-001**: Benchmark API performance before and after upgrade
- **PERF-002**: Leverage .NET 10 performance improvements
- **PERF-003**: Optimize EF Core queries with new .NET 10 features
- **PERF-004**: Monitor memory usage and garbage collection improvements

### Constraints

- **CON-001**: Zero downtime deployment required
- **CON-002**: Must maintain database schema compatibility
- **CON-003**: API endpoints must remain unchanged (no breaking changes)
- **CON-004**: Development environment must support .NET 10 SDK
- **CON-005**: All developers must upgrade to .NET 10 SDK locally

### Guidelines

- **GUD-001**: Follow Microsoft's .NET 10 migration best practices
- **GUD-002**: Use incremental upgrade approach with rollback capability
- **GUD-003**: Document all breaking changes and workarounds
- **GUD-004**: Maintain code quality standards throughout upgrade
- **GUD-005**: Use feature flags for gradual rollout if needed

### Patterns to Follow

- **PAT-001**: Continue using Minimal APIs pattern
- **PAT-002**: Maintain Vertical Slice Architecture
- **PAT-003**: Keep endpoint-based organization structure
- **PAT-004**: Follow ASP.NET Core 10 conventions
- **PAT-005**: Use built-in dependency injection improvements

## 2. Implementation Steps

### Phase 1: Pre-Upgrade Assessment & Preparation

**GOAL-001**: Assess current state, identify breaking changes, and prepare upgrade strategy

| Task | Description | Completed | Date |
|------|-------------|-----------|------|
| TASK-001 | Install .NET 10 SDK on development machines | | |
| TASK-002 | Create feature branch `upgrade/dotnet-10` from main | | |
| TASK-003 | Document current application behavior and API contracts | | |
| TASK-004 | Run full test suite and document baseline results | | |
| TASK-005 | Review .NET 10 breaking changes documentation | | |
| TASK-006 | Analyze current NuGet package compatibility with .NET 10 | | |
| TASK-007 | Create rollback plan and backup strategy | | |
| TASK-008 | Set up .NET 10 SDK in local Docker environment | | |
| TASK-009 | Review Microsoft.AspNetCore 10 migration guide | | |
| TASK-010 | Identify deprecated APIs used in current codebase | | |

### Phase 2: Project File & SDK Updates

**GOAL-002**: Update project file to target .NET 10.0 framework

| Task | Description | Completed | Date |
|------|-------------|-----------|------|
| TASK-011 | Update `TargetFramework` in Chirper.csproj from `net8.0` to `net10.0` | | |
| TASK-012 | Verify SDK version in global.json (if exists) or create one | | |
| TASK-013 | Update Dockerfile base images to use .NET 10 runtime | | |
| TASK-014 | Update Dockerfile SDK images to use .NET 10 SDK | | |
| TASK-015 | Verify implicit usings compatibility with .NET 10 | | |
| TASK-016 | Update EditorConfig for .NET 10 language features | | |
| TASK-017 | Review and update nullable reference type settings | | |

### Phase 3: NuGet Package Updates

**GOAL-003**: Upgrade all NuGet packages to .NET 10-compatible versions

| Task | Description | Completed | Date |
|------|-------------|-----------|------|
| TASK-018 | Update `FluentValidation` to latest .NET 10 compatible version | | |
| TASK-019 | Update `FluentValidation.DependencyInjectionExtensions` to match | | |
| TASK-020 | Update `Microsoft.AspNetCore.Authentication.JwtBearer` to 10.0.x | | |
| TASK-021 | Update `Microsoft.AspNetCore.OpenApi` to 10.0.x | | |
| TASK-022 | Update `Microsoft.EntityFrameworkCore` to 10.0.x | | |
| TASK-023 | Update `Microsoft.EntityFrameworkCore.Design` to 10.0.x | | |
| TASK-024 | Update `Microsoft.EntityFrameworkCore.SqlServer` to 10.0.x | | |
| TASK-025 | Update `Microsoft.VisualStudio.Azure.Containers.Tools.Targets` | | |
| TASK-026 | Update `Serilog.AspNetCore` to latest .NET 10 compatible version | | |
| TASK-027 | Update `Sqids` to latest version | | |
| TASK-028 | Update `Swashbuckle.AspNetCore` to latest version | | |
| TASK-029 | Run `dotnet restore` and resolve any dependency conflicts | | |
| TASK-030 | Run `dotnet list package --vulnerable` to check for vulnerabilities | | |
| TASK-031 | Run `dotnet list package --outdated` to identify outdated packages | | |

### Phase 4: Code Modernization & API Updates

**GOAL-004**: Update code to leverage .NET 10 features and fix breaking changes

| Task | Description | Completed | Date |
|------|-------------|-----------|------|
| TASK-032 | Review Program.cs for .NET 10 hosting model changes | | |
| TASK-033 | Update ConfigureServices.cs for DI improvements in .NET 10 | | |
| TASK-034 | Review ConfigureApp.cs for middleware changes | | |
| TASK-035 | Update JWT authentication configuration for .NET 10 | | |
| TASK-036 | Review all Minimal API endpoint definitions | | |
| TASK-037 | Update Entity Framework Core configurations | | |
| TASK-038 | Leverage new EF Core 10 features (if applicable) | | |
| TASK-039 | Review and update filter implementations | | |
| TASK-040 | Update validation logic for FluentValidation changes | | |
| TASK-041 | Review ClaimsPrincipal extensions for .NET 10 | | |
| TASK-042 | Update IEndpoint interface implementation if needed | | |
| TASK-043 | Apply new C# 13 language features where beneficial | | |
| TASK-044 | Review async/await patterns for .NET 10 improvements | | |
| TASK-045 | Update logging configuration for .NET 10 | | |

### Phase 5: Database & EF Core Migration

**GOAL-005**: Ensure database compatibility and leverage EF Core 10 improvements

| Task | Description | Completed | Date |
|------|-------------|-----------|------|
| TASK-046 | Test EF Core 10 with existing database schema | | |
| TASK-047 | Review query performance with EF Core 10 | | |
| TASK-048 | Update database context configurations | | |
| TASK-049 | Test all CRUD operations with EF Core 10 | | |
| TASK-050 | Verify migrations work with EF Core 10 | | |
| TASK-051 | Test connection resilience with SQL Server | | |
| TASK-052 | Benchmark query performance before/after | | |
| TASK-053 | Update seeding logic if affected by EF Core changes | | |

### Phase 6: Testing & Validation

**GOAL-006**: Comprehensive testing to ensure upgrade success

| Task | Description | Completed | Date |
|------|-------------|-----------|------|
| TASK-054 | Build solution with `dotnet build` and fix errors | | |
| TASK-055 | Run all unit tests and fix failures | | |
| TASK-056 | Run all integration tests and fix failures | | |
| TASK-057 | Test authentication flows (signup, login) | | |
| TASK-058 | Test all API endpoints manually | | |
| TASK-059 | Verify OpenAPI/Swagger documentation generation | | |
| TASK-060 | Test JWT token generation and validation | | |
| TASK-061 | Test database operations (CRUD) | | |
| TASK-062 | Test validation logic and error handling | | |
| TASK-063 | Test filters (authentication, validation, logging) | | |
| TASK-064 | Test paging functionality | | |
| TASK-065 | Load test with realistic traffic patterns | | |
| TASK-066 | Test Docker container build and run | | |
| TASK-067 | Verify logging and monitoring still works | | |

### Phase 7: Performance Benchmarking

**GOAL-007**: Verify performance improvements and identify regressions

| Task | Description | Completed | Date |
|------|-------------|-----------|------|
| TASK-068 | Create performance baseline from .NET 8.0 version | | |
| TASK-069 | Run performance tests on .NET 10 version | | |
| TASK-070 | Compare startup time between versions | | |
| TASK-071 | Compare request throughput between versions | | |
| TASK-072 | Compare memory usage between versions | | |
| TASK-073 | Analyze GC performance improvements | | |
| TASK-074 | Test database query performance | | |
| TASK-075 | Document performance improvements/regressions | | |

### Phase 8: CI/CD Pipeline Updates

**GOAL-008**: Update continuous integration and deployment pipelines

| Task | Description | Completed | Date |
|------|-------------|-----------|------|
| TASK-076 | Update GitHub Actions workflow for .NET 10 SDK | | |
| TASK-077 | Update Azure DevOps pipeline for .NET 10 SDK | | |
| TASK-078 | Update build agents to support .NET 10 | | |
| TASK-079 | Update Docker build pipeline for .NET 10 | | |
| TASK-080 | Test pipeline builds with .NET 10 | | |
| TASK-081 | Update deployment scripts for .NET 10 runtime | | |
| TASK-082 | Update environment variables if needed | | |
| TASK-083 | Test automated deployment to staging | | |

### Phase 9: Documentation Updates

**GOAL-009**: Update all documentation to reflect .NET 10 upgrade

| Task | Description | Completed | Date |
|------|-------------|-----------|------|
| TASK-084 | Update README.md with .NET 10 requirements | | |
| TASK-085 | Update development setup instructions | | |
| TASK-086 | Document breaking changes encountered | | |
| TASK-087 | Update API documentation | | |
| TASK-088 | Create migration guide for team members | | |
| TASK-089 | Update Docker documentation | | |
| TASK-090 | Document new .NET 10 features utilized | | |
| TASK-091 | Create upgrade checklist for future reference | | |
| TASK-092 | Update architecture decision records (ADRs) | | |

### Phase 10: Deployment & Rollout

**GOAL-010**: Deploy .NET 10 version to production safely

| Task | Description | Completed | Date |
|------|-------------|-----------|------|
| TASK-093 | Deploy to development environment | | |
| TASK-094 | Verify dev environment functionality | | |
| TASK-095 | Deploy to staging environment | | |
| TASK-096 | Run smoke tests in staging | | |
| TASK-097 | Perform UAT in staging environment | | |
| TASK-098 | Create production deployment plan | | |
| TASK-099 | Schedule production deployment window | | |
| TASK-100 | Deploy to production with blue-green strategy | | |
| TASK-101 | Monitor production metrics post-deployment | | |
| TASK-102 | Verify all services are healthy | | |
| TASK-103 | Monitor error rates and performance | | |
| TASK-104 | Execute rollback if critical issues found | | |
| TASK-105 | Merge upgrade branch to main after success | | |

## 3. Alternatives

### Alternative Approaches Considered

- **ALT-001**: **Incremental Package Updates Before Framework Upgrade**
  - Update all packages to latest .NET 8 compatible versions first
  - Then upgrade framework to .NET 10
  - **Not chosen**: Adds extra steps without significant benefit for this project size

- **ALT-002**: **Use .NET Upgrade Assistant Tool**
  - Automated upgrade using Microsoft's upgrade assistant
  - **Not chosen**: Project is already well-structured; manual upgrade provides more control

- **ALT-003**: **Upgrade to .NET 9 First, Then .NET 10**
  - Staged upgrade through intermediate version
  - **Not chosen**: Unnecessary for this project; .NET 8 to 10 is well-documented

- **ALT-004**: **Containerized Dual-Version Deployment**
  - Run .NET 8 and .NET 10 versions simultaneously
  - **Not chosen**: Adds complexity without clear benefit for this project

- **ALT-005**: **Complete Rewrite for .NET 10**
  - Start fresh with .NET 10 project template
  - **Not chosen**: Existing architecture is solid; upgrade is more efficient

## 4. Dependencies

### External Dependencies

- **DEP-001**: .NET 10.0 SDK - Required for building and running
- **DEP-002**: FluentValidation 11.9.x+ - Must support .NET 10
- **DEP-003**: EF Core 10.0.x - Database access layer
- **DEP-004**: SQL Server - Database compatibility with EF Core 10
- **DEP-005**: JWT Bearer Authentication 10.0.x - Security
- **DEP-006**: Serilog.AspNetCore - Logging library
- **DEP-007**: Swashbuckle.AspNetCore - OpenAPI documentation
- **DEP-008**: Docker runtime supporting .NET 10
- **DEP-009**: GitHub Actions or Azure DevOps with .NET 10 SDK
- **DEP-010**: Visual Studio 2025 or Rider 2025+ for development

### Internal Dependencies

- **DEP-011**: All developers must upgrade local .NET SDK
- **DEP-012**: CI/CD pipeline must support .NET 10
- **DEP-013**: Production hosting environment must support .NET 10 runtime
- **DEP-014**: Monitoring and logging infrastructure compatibility

### Breaking Changes to Monitor

- **DEP-015**: ASP.NET Core 10 authentication changes
- **DEP-016**: EF Core 10 query translation updates
- **DEP-017**: Minimal API improvements and changes
- **DEP-018**: Dependency injection behavior changes
- **DEP-019**: Configuration system updates

## 5. Files

### Project Files to Modify

- **FILE-001**: `src/Chirper.csproj` - Target framework and package versions
- **FILE-002**: `Dockerfile` - Base images and runtime
- **FILE-003**: `.dockerignore` - Review for .NET 10 artifacts
- **FILE-004**: `global.json` - SDK version pinning (create if not exists)
- **FILE-005**: `.editorconfig` - C# language version settings
- **FILE-006**: `README.md` - Documentation updates
- **FILE-007**: `.github/workflows/*.yml` - CI/CD pipeline updates
- **FILE-008**: `azure-pipelines.yml` - Azure DevOps pipeline (if exists)

### Core Application Files to Review

- **FILE-009**: `src/Program.cs` - Hosting and startup
- **FILE-010**: `src/ConfigureServices.cs` - Dependency injection
- **FILE-011**: `src/ConfigureApp.cs` - Middleware pipeline
- **FILE-012**: `src/Endpoints.cs` - Endpoint registration
- **FILE-013**: `src/Authentication/Services/Jwt.cs` - JWT service
- **FILE-014**: All `*Endpoints/*.cs` files - API endpoints
- **FILE-015**: All `*Filter*.cs` files - Endpoint filters
- **FILE-016**: `src/Common/Api/IEndpoint.cs` - Endpoint interface

### Configuration Files

- **FILE-017**: `appsettings.json` - Review for .NET 10 config changes
- **FILE-018**: `appsettings.Development.json` - Development settings
- **FILE-019**: `appsettings.Production.json` - Production settings

### Database Files

- **FILE-020**: All Entity Framework DbContext files
- **FILE-021**: All Entity Configuration files
- **FILE-022**: Migration files - Verify compatibility

## 6. Testing

### Unit Tests

- **TEST-001**: All existing unit tests must pass
- **TEST-002**: Test JWT token generation with .NET 10
- **TEST-003**: Test validation logic with FluentValidation
- **TEST-004**: Test ClaimsPrincipal extensions
- **TEST-005**: Test filter implementations
- **TEST-006**: Test endpoint request/response handling
- **TEST-007**: Test error handling and problem details

### Integration Tests

- **TEST-008**: Test full authentication flow (signup, login)
- **TEST-009**: Test protected endpoint access
- **TEST-010**: Test all CRUD operations through API
- **TEST-011**: Test database operations with EF Core 10
- **TEST-012**: Test API paging functionality
- **TEST-013**: Test OpenAPI documentation generation
- **TEST-014**: Test validation error responses
- **TEST-015**: Test logging functionality

### Performance Tests

- **TEST-016**: Benchmark startup time
- **TEST-017**: Benchmark request throughput
- **TEST-018**: Benchmark database query performance
- **TEST-019**: Benchmark memory usage under load
- **TEST-020**: Benchmark GC performance
- **TEST-021**: Load test with concurrent users
- **TEST-022**: Stress test with high traffic

### System Tests

- **TEST-023**: Test Docker container build
- **TEST-024**: Test Docker container startup
- **TEST-025**: Test in development environment
- **TEST-026**: Test in staging environment
- **TEST-027**: Smoke tests in production
- **TEST-028**: Test CI/CD pipeline builds

### Security Tests

- **TEST-029**: Test JWT authentication still works
- **TEST-030**: Test authorization policies
- **TEST-031**: Test HTTPS/TLS configuration
- **TEST-032**: Test security headers
- **TEST-033**: Vulnerability scan with updated packages

## 7. Risks & Assumptions

### Risks

- **RISK-001**: **Breaking changes in .NET 10 APIs**
  - *Mitigation*: Review Microsoft docs, test thoroughly, maintain rollback plan
  - *Severity*: Medium
  - *Probability*: Low

- **RISK-002**: **NuGet package incompatibility**
  - *Mitigation*: Test all packages, have alternatives identified
  - *Severity*: Medium
  - *Probability*: Low

- **RISK-003**: **Performance regression**
  - *Mitigation*: Comprehensive benchmarking, performance testing
  - *Severity*: Medium
  - *Probability*: Very Low

- **RISK-004**: **Database compatibility issues with EF Core 10**
  - *Mitigation*: Test migrations, backup database, verify queries
  - *Severity*: High
  - *Probability*: Very Low

- **RISK-005**: **CI/CD pipeline disruption**
  - *Mitigation*: Test pipeline changes in feature branch first
  - *Severity*: Medium
  - *Probability*: Low

- **RISK-006**: **Production deployment issues**
  - *Mitigation*: Blue-green deployment, rollback plan, staged rollout
  - *Severity*: High
  - *Probability*: Low

- **RISK-007**: **Developer environment setup problems**
  - *Mitigation*: Clear documentation, team support, troubleshooting guide
  - *Severity*: Low
  - *Probability*: Medium

- **RISK-008**: **Authentication/Security vulnerabilities**
  - *Mitigation*: Security testing, code review, vulnerability scanning
  - *Severity*: High
  - *Probability*: Very Low

### Assumptions

- **ASSUMPTION-001**: .NET 10 SDK is stable and production-ready
- **ASSUMPTION-002**: All NuGet packages have .NET 10 compatible versions
- **ASSUMPTION-003**: SQL Server remains compatible with EF Core 10
- **ASSUMPTION-004**: No major API contract changes required
- **ASSUMPTION-005**: Current architecture works well with .NET 10
- **ASSUMPTION-006**: Performance will improve or remain similar
- **ASSUMPTION-007**: Team has capacity for thorough testing
- **ASSUMPTION-008**: Hosting environment supports .NET 10 runtime
- **ASSUMPTION-009**: No downstream service dependencies on .NET 8
- **ASSUMPTION-010**: Migration can be completed in planned timeframe

## 8. Related Specifications / Further Reading

### Microsoft Official Documentation

- [What's new in .NET 10](https://docs.microsoft.com/dotnet/core/whats-new/dotnet-10)
- [.NET 10 Breaking Changes](https://docs.microsoft.com/dotnet/core/compatibility/10.0)
- [Migrate from ASP.NET Core 8.0 to 10.0](https://docs.microsoft.com/aspnet/core/migration/80-to-100)
- [Entity Framework Core 10 Release Notes](https://docs.microsoft.com/ef/core/what-is-new/ef-core-10.0/whatsnew)
- [C# 13 Language Features](https://docs.microsoft.com/dotnet/csharp/whats-new/csharp-13)

### Package Documentation

- [FluentValidation Upgrade Guide](https://docs.fluentvalidation.net/en/latest/upgrade-to-11.html)
- [Serilog ASP.NET Core Integration](https://github.com/serilog/serilog-aspnetcore)
- [Swashbuckle.AspNetCore Documentation](https://github.com/domaindrivendev/Swashbuckle.AspNetCore)

### Best Practices & Guides

- [ASP.NET Core Performance Best Practices](https://docs.microsoft.com/aspnet/core/performance/performance-best-practices)
- [.NET Upgrade Assistant Documentation](https://docs.microsoft.com/dotnet/core/porting/upgrade-assistant-overview)
- [Docker Best Practices for .NET](https://docs.microsoft.com/dotnet/core/docker/build-container)

### Internal Resources

- `copilot-resources/instructions/dotnet-upgrade.instructions.md` - Upgrade instructions
- `copilot-resources/prompts/dotnet-upgrade.prompt.md` - Upgrade prompts
- `copilot-resources/agents/dotnet-upgrade.agent.md` - Upgrade agent
- Project README.md for architecture overview

### Related Implementation Plans

- (Future) Performance optimization plan post-upgrade
- (Future) Feature development leveraging .NET 10 capabilities

---

## Implementation Timeline

**Estimated Duration**: 2-3 weeks

- **Phase 1-2**: 2-3 days (Assessment & Project Updates)
- **Phase 3-4**: 3-4 days (Package Updates & Code Changes)
- **Phase 5-7**: 3-4 days (Database, Testing & Benchmarking)
- **Phase 8-9**: 2-3 days (CI/CD & Documentation)
- **Phase 10**: 3-5 days (Deployment with monitoring period)

## Success Criteria

✅ All tasks completed successfully
✅ All tests passing (unit, integration, system)
✅ Performance equal or better than .NET 8.0
✅ Zero downtime deployment achieved
✅ No critical bugs in production for 1 week post-deployment
✅ Team successfully using .NET 10 for development
✅ Documentation fully updated

## Sign-off

This plan should be reviewed and approved by:
- [ ] Technical Lead
- [ ] Development Team
- [ ] DevOps Team
- [ ] QA Team
- [ ] Product Owner

---

**Plan Version**: 1.0  
**Created**: 2026-02-16  
**Status**: Ready for Implementation
