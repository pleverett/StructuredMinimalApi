# Workflow Catalog for ASP.NET Core Development

This document provides detailed, actionable workflows using the Copilot resources for various development scenarios.

## 📑 Table of Contents

1. [Feature Development Workflows](#feature-development-workflows)
2. [Quality Assurance Workflows](#quality-assurance-workflows)
3. [DevOps Workflows](#devops-workflows)
4. [Architecture Workflows](#architecture-workflows)
5. [Maintenance Workflows](#maintenance-workflows)
6. [Emergency Workflows](#emergency-workflows)
7. [Team Collaboration Workflows](#team-collaboration-workflows)
8. [Learning & Documentation Workflows](#learning--documentation-workflows)

---

## Feature Development Workflows

### 🎯 Workflow 1: New API Endpoint (TDD Approach)

**When to use**: Adding a new REST API endpoint with full TDD coverage

**Resources needed**:
- Instructions: `csharp.instructions.md`, `aspnet-rest-apis.instructions.md`
- Prompts: `csharp-xunit.prompt.md`, `aspnet-minimal-api-openapi.prompt.md`
- Agents: `tdd-red.agent.md`, `tdd-green.agent.md`, `tdd-refactor.agent.md`

**Steps**:

1. **Requirements Clarification**
   ```
   @workspace using first-ask.prompt, clarify requirements for: [feature description]
   ```

2. **Write Specification**
   ```
   @workspace acting as specification.agent, create a spec for: [endpoint details]
   Document: Request/Response models, validation rules, error cases
   ```

3. **Design API Contract**
   ```
   @workspace using aspnet-minimal-api-openapi.prompt, design OpenAPI spec for:
   [endpoint path, methods, request/response bodies]
   ```

4. **RED: Write Failing Tests**
   ```
   @workspace acting as tdd-red.agent, using csharp-xunit.prompt:
   Create comprehensive tests for [endpoint] including:
   - Happy path scenarios
   - Validation failures
   - Edge cases
   - Integration tests
   ```

5. **GREEN: Implement Endpoint**
   ```
   @workspace acting as expert-dotnet-software-engineer.agent:
   Implement the minimal code to make tests pass:
   #file:tests/[test-file].cs
   Follow aspnet-rest-apis.instructions
   ```

6. **REFACTOR: Optimize**
   ```
   @workspace acting as tdd-refactor.agent:
   Refactor implementation while keeping tests green
   Apply dotnet-best-practices
   ```

7. **Code Review**
   ```
   @workspace using gilfoyle.agent and code-review-generic.instructions:
   Review #file:src/[implementation-file].cs
   ```

8. **Security Check**
   ```
   @workspace acting as se-security-reviewer.agent:
   Security audit of #file:src/[implementation-file].cs
   Using security-and-owasp.instructions
   ```

9. **Documentation**
   ```
   @workspace using csharp-docs.prompt:
   Add XML documentation to #file:src/[implementation-file].cs
   
   @workspace using documentation-writer.prompt:
   Create API documentation for [endpoint]
   ```

**Expected Outcome**: Production-ready endpoint with tests, docs, and security review

**Time Estimate**: 2-4 hours for complex endpoint

---

### 🎯 Workflow 2: Feature with Database Operations

**When to use**: Implementing features that require database access with EF Core

**Resources needed**:
- Instructions: `csharp.instructions.md`, `dotnet-architecture-good-practices.instructions.md`
- Prompts: `ef-core.prompt.md`, `sql-optimization.prompt.md`
- Agents: `expert-dotnet-software-engineer.agent.md`, `api-architect.agent.md`

**Steps**:

1. **Data Model Design**
   ```
   @workspace acting as api-architect.agent:
   Design entity models for: [feature description]
   Consider: relationships, constraints, indexes
   ```

2. **Entity Configuration**
   ```
   @workspace using ef-core.prompt:
   Create entity configurations for: [entities]
   Include: FluentAPI mappings, indexes, constraints
   ```

3. **Repository Pattern**
   ```
   @workspace following dotnet-architecture-good-practices.instructions:
   Implement repository for [entity]
   Use: Generic repository with specification pattern
   ```

4. **Query Optimization**
   ```
   @workspace using sql-optimization.prompt:
   Analyze and optimize these EF Core queries:
   #file:src/[repository-file].cs
   ```

5. **Migration**
   ```
   @workspace using ef-core.prompt:
   Guide me through creating migration for these changes
   ```

6. **Integration Tests**
   ```
   @workspace using csharp-xunit.prompt:
   Create integration tests for data access:
   - CRUD operations
   - Query filters
   - Transaction handling
   ```

**Expected Outcome**: Optimized data access layer with tests

**Time Estimate**: 3-5 hours

---

### 🎯 Workflow 3: Async API Implementation

**When to use**: Converting synchronous code to async or implementing new async operations

**Resources needed**:
- Instructions: `csharp.instructions.md`, `performance-optimization.instructions.md`
- Prompts: `csharp-async.prompt.md`
- Agents: `expert-dotnet-software-engineer.agent.md`

**Steps**:

1. **Identify Async Opportunities**
   ```
   @workspace using performance-optimization.instructions:
   Analyze #file:src/[file].cs for async conversion opportunities
   ```

2. **Convert to Async**
   ```
   @workspace using csharp-async.prompt:
   Convert these methods to async/await pattern:
   #file:src/[file].cs
   Preserve functionality and add cancellation token support
   ```

3. **Update Call Sites**
   ```
   @workspace:
   Find all call sites of [method] and update to async
   ```

4. **Test Async Behavior**
   ```
   @workspace using csharp-xunit.prompt:
   Create async tests including:
   - Concurrent operations
   - Cancellation scenarios
   - Exception handling
   ```

5. **Performance Verification**
   ```
   @workspace using performance-optimization.instructions:
   Create benchmark comparing sync vs async versions
   ```

**Expected Outcome**: Fully async implementation with verified performance

**Time Estimate**: 2-3 hours

---

## Quality Assurance Workflows

### 🎯 Workflow 4: Comprehensive Test Suite

**When to use**: Creating or expanding test coverage for existing code

**Resources needed**:
- Prompts: `csharp-xunit.prompt.md`, `breakdown-test.prompt.md`
- Agents: `tdd-red.agent.md`, `principal-software-engineer.agent.md`

**Steps**:

1. **Test Strategy**
   ```
   @workspace using breakdown-test.prompt:
   Analyze #file:src/[file].cs
   Create test strategy covering:
   - Unit tests
   - Integration tests
   - Edge cases
   ```

2. **Generate Tests**
   ```
   @workspace acting as tdd-red.agent, using csharp-xunit.prompt:
   Generate complete test suite for:
   #file:src/[file].cs
   ```

3. **Coverage Analysis**
   ```
   @workspace:
   Identify untested code paths in #file:src/[file].cs
   Suggest additional test cases
   ```

4. **Test Refactoring**
   ```
   @workspace using dotnet-best-practices.prompt:
   Refactor tests for:
   - Better readability
   - DRY principle
   - Arrange-Act-Assert pattern
   ```

**Expected Outcome**: Comprehensive test coverage with well-organized tests

**Time Estimate**: 1-3 hours per file

---

### 🎯 Workflow 5: Security Audit

**When to use**: Performing security review before release or after security concerns

**Resources needed**:
- Instructions: `security-and-owasp.instructions.md`
- Prompts: `sql-code-review.prompt.md`
- Agents: `se-security-reviewer.agent.md`, `critical-thinking.agent.md`

**Steps**:

1. **Initial Security Scan**
   ```
   @workspace acting as se-security-reviewer.agent:
   Using security-and-owasp.instructions:
   Perform comprehensive security audit of:
   @workspace
   Focus on: authentication, authorization, input validation, SQL injection
   ```

2. **SQL Injection Analysis**
   ```
   @workspace using sql-code-review.prompt:
   Review all database queries for injection vulnerabilities:
   #file:src/[data-access-files]
   ```

3. **Authentication Review**
   ```
   @workspace acting as se-security-reviewer.agent:
   Review authentication implementation:
   #file:src/[auth-files]
   Check: token handling, password hashing, session management
   ```

4. **Challenge Assumptions**
   ```
   @workspace acting as critical-thinking.agent:
   Challenge security assumptions in our design:
   What could go wrong? What are we missing?
   ```

5. **Remediation Plan**
   ```
   @workspace acting as implementation-plan.agent:
   Create remediation plan for identified issues:
   Prioritize by severity
   ```

**Expected Outcome**: Complete security audit with remediation plan

**Time Estimate**: 4-8 hours for full application

---

### 🎯 Workflow 6: Code Quality Review

**When to use**: Pre-PR review or periodic code quality checks

**Resources needed**:
- Instructions: `code-review-generic.instructions.md`, `dotnet-architecture-good-practices.instructions.md`
- Prompts: `dotnet-best-practices.prompt.md`, `dotnet-design-pattern-review.prompt.md`
- Agents: `gilfoyle.agent.md`, `janitor.agent.md`

**Steps**:

1. **Gilfoyle Review** (Brutal Honesty)
   ```
   @workspace acting as gilfoyle.agent:
   Review these changes with brutal honesty:
   [git diff or file references]
   ```

2. **Best Practices Check**
   ```
   @workspace using dotnet-best-practices.prompt:
   Review code against .NET best practices:
   #file:src/[files]
   ```

3. **Design Pattern Analysis**
   ```
   @workspace using dotnet-design-pattern-review.prompt:
   Analyze design patterns in:
   #file:src/[files]
   Suggest improvements
   ```

4. **Code Cleanup**
   ```
   @workspace acting as janitor.agent:
   Clean up code smells in:
   #file:src/[files]
   Apply: SOLID principles, remove dead code, simplify complexity
   ```

5. **Architecture Alignment**
   ```
   @workspace acting as se-system-architecture-reviewer.agent:
   Verify alignment with architecture:
   #file:src/[files]
   Check: separation of concerns, dependencies
   ```

**Expected Outcome**: High-quality, maintainable code ready for PR

**Time Estimate**: 1-2 hours

---

## DevOps Workflows

### 🎯 Workflow 7: CI/CD Pipeline Setup

**When to use**: Setting up or improving CI/CD pipelines

**Resources needed**:
- Instructions: `github-actions-ci-cd-best-practices.instructions.md`, `containerization-docker-best-practices.instructions.md`
- Prompts: `create-github-action-workflow-specification.prompt.md`, `multi-stage-dockerfile.prompt.md`
- Agents: `devops-expert.agent.md`, `github-actions-expert.agent.md`

**Steps**:

1. **Pipeline Strategy**
   ```
   @workspace acting as devops-expert.agent:
   Design CI/CD strategy for our ASP.NET Core app:
   - Build stages
   - Test stages
   - Deployment strategy
   - Environment promotion
   ```

2. **Dockerfile Creation**
   ```
   @workspace using multi-stage-dockerfile.prompt:
   Create optimized multi-stage Dockerfile for:
   ASP.NET Core 8 application
   Requirements: small image, security scanning, non-root user
   ```

3. **GitHub Actions Workflow**
   ```
   @workspace acting as github-actions-expert.agent:
   Using create-github-action-workflow-specification.prompt:
   Create workflow for:
   - Build on PR
   - Run tests
   - Security scanning
   - Docker build and push
   - Deploy to staging/production
   ```

4. **Container Best Practices**
   ```
   @workspace using containerization-docker-best-practices.instructions:
   Review and optimize:
   #file:Dockerfile
   ```

5. **Kubernetes Deployment**
   ```
   @workspace using kubernetes-deployment-best-practices.instructions:
   Create K8s manifests:
   - Deployment
   - Service
   - Ingress
   - ConfigMaps/Secrets
   ```

**Expected Outcome**: Production-ready CI/CD pipeline

**Time Estimate**: 4-6 hours

---

### 🎯 Workflow 8: Performance Optimization

**When to use**: Addressing performance issues or proactive optimization

**Resources needed**:
- Instructions: `performance-optimization.instructions.md`
- Prompts: `sql-optimization.prompt.md`, `csharp-async.prompt.md`
- Agents: `expert-dotnet-software-engineer.agent.md`, `task-researcher.agent.md`

**Steps**:

1. **Performance Analysis**
   ```
   @workspace acting as task-researcher.agent:
   Analyze performance bottlenecks in:
   @workspace
   Suggest profiling approaches
   ```

2. **Database Optimization**
   ```
   @workspace using sql-optimization.prompt:
   Optimize database queries in:
   #file:src/[data-files]
   Add: indexes, query hints, proper pagination
   ```

3. **Async Conversion**
   ```
   @workspace using csharp-async.prompt:
   Convert I/O-bound operations to async:
   #file:src/[files-with-io]
   ```

4. **Caching Strategy**
   ```
   @workspace using performance-optimization.instructions:
   Design caching strategy for:
   [specific features or endpoints]
   Consider: distributed cache, output caching, in-memory cache
   ```

5. **Load Testing Plan**
   ```
   @workspace:
   Create load testing plan using:
   - JMeter or K6
   - Key endpoints to test
   - Expected load patterns
   - Performance targets
   ```

**Expected Outcome**: Measurably improved performance

**Time Estimate**: 6-10 hours

---

## Architecture Workflows

### 🎯 Workflow 9: Architecture Design & ADR

**When to use**: Making significant architectural decisions

**Resources needed**:
- Instructions: `dotnet-architecture-good-practices.instructions.md`
- Prompts: `architecture-blueprint-generator.prompt.md`, `create-architectural-decision-record.prompt.md`
- Agents: `arch.agent.md`, `adr-generator.agent.md`, `critical-thinking.agent.md`

**Steps**:

1. **Architecture Exploration**
   ```
   @workspace acting as arch.agent:
   Design architecture for: [feature/system]
   Consider: scalability, maintainability, testability
   Options to evaluate: [list alternatives]
   ```

2. **Generate Blueprint**
   ```
   @workspace using architecture-blueprint-generator.prompt:
   Create architecture blueprint for: [system]
   Include: components, data flow, integration points
   ```

3. **Challenge Design**
   ```
   @workspace acting as critical-thinking.agent:
   Challenge this architecture design:
   [paste design]
   What could fail? What's missing? What's over-engineered?
   ```

4. **Create ADR**
   ```
   @workspace using create-architectural-decision-record.prompt:
   Document ADR for decision: [decision name]
   Context: [context]
   Options considered: [alternatives]
   Decision: [chosen approach]
   Consequences: [trade-offs]
   ```

5. **Architecture Review**
   ```
   @workspace acting as se-system-architecture-reviewer.agent:
   Review architecture against:
   - SOLID principles
   - Clean Architecture
   - Vertical Slice Architecture (for this project)
   ```

6. **Implementation Planning**
   ```
   @workspace acting as implementation-plan.agent:
   Break down architecture implementation:
   - Phase 1: Core infrastructure
   - Phase 2: Feature implementation
   - Phase 3: Cross-cutting concerns
   ```

**Expected Outcome**: Well-documented architectural decision with implementation plan

**Time Estimate**: 4-8 hours

---

### 🎯 Workflow 10: Refactoring Legacy Code

**When to use**: Modernizing or improving legacy codebases

**Resources needed**:
- Instructions: `dotnet-upgrade.instructions.md`, `dotnet-architecture-good-practices.instructions.md`
- Prompts: `refactor-plan.prompt.md`, `review-and-refactor.prompt.md`, `generate-custom-instructions-from-codebase.prompt.md`
- Agents: `tech-debt-remediation-plan.agent.md`, `janitor.agent.md`, `principal-software-engineer.agent.md`

**Steps**:

1. **Codebase Analysis**
   ```
   @workspace using generate-custom-instructions-from-codebase.prompt:
   Analyze legacy codebase:
   @workspace
   Generate custom instructions for this codebase
   ```

2. **Technical Debt Assessment**
   ```
   @workspace acting as tech-debt-remediation-plan.agent:
   Assess technical debt in:
   @workspace
   Categorize by: severity, effort, impact
   ```

3. **Refactoring Strategy**
   ```
   @workspace using refactor-plan.prompt:
   Create refactoring plan for: [component/module]
   Approach: strangler fig pattern
   ```

4. **Version Upgrade Plan**
   ```
   @workspace using dotnet-upgrade.instructions and dotnet-upgrade.prompt:
   Plan upgrade from .NET [old] to .NET [new]
   Breaking changes, migration steps, testing strategy
   ```

5. **Incremental Refactoring**
   ```
   @workspace acting as janitor.agent:
   Using review-and-refactor.prompt:
   Refactor #file:src/[legacy-file].cs
   Preserve behavior, add tests first
   ```

6. **Architectural Improvements**
   ```
   @workspace acting as arch.agent:
   Redesign [module] following dotnet-architecture-good-practices
   Migration path from current to target state
   ```

7. **Risk Assessment**
   ```
   @workspace acting as critical-thinking.agent:
   What are the risks of this refactoring?
   Mitigation strategies?
   Rollback plan?
   ```

**Expected Outcome**: Modernized, maintainable codebase

**Time Estimate**: Weeks to months (iterative)

---

## Maintenance Workflows

### 🎯 Workflow 11: Bug Fix Workflow

**When to use**: Addressing reported bugs

**Resources needed**:
- Agents: `debug.agent.md`, `task-researcher.agent.md`, `tdd-red.agent.md`
- Prompts: `csharp-xunit.prompt.md`

**Steps**:

1. **Bug Investigation**
   ```
   @workspace acting as debug.agent:
   Analyze bug: [bug description]
   Relevant code: #file:src/[suspected-files]
   Logs: [error messages]
   ```

2. **Root Cause Analysis**
   ```
   @workspace acting as task-researcher.agent:
   Research root cause of: [bug]
   Review similar issues, stack traces, data flow
   ```

3. **Reproduce with Test**
   ```
   @workspace acting as tdd-red.agent:
   Using csharp-xunit.prompt:
   Write failing test that reproduces: [bug]
   #file:tests/[test-file].cs
   ```

4. **Implement Fix**
   ```
   @workspace acting as expert-dotnet-software-engineer.agent:
   Fix bug to make test pass:
   #file:src/[file-with-bug].cs
   Minimal change principle
   ```

5. **Regression Testing**
   ```
   @workspace:
   Identify related functionality that might be affected
   Suggest additional regression tests
   ```

6. **Review**
   ```
   @workspace acting as gilfoyle.agent:
   Review bug fix:
   [git diff]
   ```

**Expected Outcome**: Fixed bug with test coverage and no regressions

**Time Estimate**: 1-4 hours

---

### 🎯 Workflow 12: Dependency Update

**When to use**: Updating NuGet packages or .NET version

**Resources needed**:
- Instructions: `dotnet-upgrade.instructions.md`
- Prompts: `dotnet-upgrade.prompt.md`
- Agents: `expert-dotnet-software-engineer.agent.md`, `devops-expert.agent.md`

**Steps**:

1. **Update Analysis**
   ```
   @workspace using dotnet-upgrade.prompt:
   Analyze impact of updating:
   [package] from [old version] to [new version]
   Breaking changes? Migration steps?
   ```

2. **Update Strategy**
   ```
   @workspace:
   Plan update strategy:
   - Update dependencies first or runtime first?
   - Test in isolation or together?
   - Rollback plan?
   ```

3. **Implement Updates**
   ```
   @workspace acting as expert-dotnet-software-engineer.agent:
   Guide me through updating [package/runtime]
   Handle breaking changes
   ```

4. **Test Changes**
   ```
   @workspace:
   Run existing tests
   Identify any test failures
   Update tests if API changes
   ```

5. **CI/CD Verification**
   ```
   @workspace acting as devops-expert.agent:
   Update CI/CD pipeline for new version
   Verify builds, tests, deployments
   ```

**Expected Outcome**: Updated dependencies with passing tests

**Time Estimate**: 2-6 hours

---

## Emergency Workflows

### 🎯 Workflow 13: Production Hotfix

**When to use**: Critical production issue requiring immediate fix

**Resources needed**:
- Agents: `debug.agent.md`, `se-security-reviewer.agent.md`, `devops-expert.agent.md`
- Instructions: `security-and-owasp.instructions.md`

**Steps** (Executed Rapidly):

1. **Triage** (5 minutes)
   ```
   @workspace acting as debug.agent:
   URGENT: Production issue:
   [error, logs, symptoms]
   Immediate assessment and quick fix options
   ```

2. **Quick Security Check** (5 minutes)
   ```
   @workspace acting as se-security-reviewer.agent:
   Is this a security issue?
   [issue details]
   Immediate containment steps?
   ```

3. **Hotfix Branch** (2 minutes)
   ```
   git checkout -b hotfix/[issue-name] production
   ```

4. **Implement Minimal Fix** (15-30 minutes)
   ```
   @workspace acting as expert-dotnet-software-engineer.agent:
   Minimal fix for: [issue]
   #file:src/[problem-file].cs
   NO refactoring, NO features, ONLY fix
   ```

5. **Rapid Testing** (10 minutes)
   ```
   @workspace:
   Quick test cases for this hotfix:
   [describe fix]
   ```

6. **Expedited Review** (10 minutes)
   ```
   @workspace acting as gilfoyle.agent:
   EXPEDITED review of hotfix:
   [git diff]
   Focus: correctness, no side effects
   ```

7. **Deploy** (as needed)
   ```
   @workspace acting as devops-expert.agent:
   Deploy hotfix safely:
   - Canary deployment?
   - Rollback plan ready?
   ```

8. **Post-Mortem** (Later)
   ```
   @workspace:
   Create post-mortem for: [issue]
   Root cause, fix, prevention measures
   ```

**Expected Outcome**: Production stabilized quickly

**Time Estimate**: 30-90 minutes

---

### 🎯 Workflow 14: Security Incident Response

**When to use**: Security vulnerability discovered or exploited

**Resources needed**:
- Instructions: `security-and-owasp.instructions.md`
- Agents: `se-security-reviewer.agent.md`, `critical-thinking.agent.md`, `devops-expert.agent.md`

**Steps**:

1. **Assess Severity** (Immediate)
   ```
   @workspace acting as se-security-reviewer.agent:
   SECURITY INCIDENT:
   [vulnerability details]
   Severity? Exploit in the wild? Immediate containment?
   ```

2. **Containment** (Immediate)
   ```
   @workspace acting as devops-expert.agent:
   Containment steps for:
   [vulnerability]
   WAF rules? Rate limiting? Service isolation?
   ```

3. **Impact Analysis**
   ```
   @workspace acting as critical-thinking.agent:
   Security impact analysis:
   - What data is at risk?
   - Who is affected?
   - What's the blast radius?
   ```

4. **Remediation**
   ```
   @workspace acting as se-security-reviewer.agent:
   Using security-and-owasp.instructions:
   Implement fix for: [vulnerability]
   #file:src/[vulnerable-file].cs
   ```

5. **Verification**
   ```
   @workspace:
   Create security test to verify fix:
   [vulnerability scenario]
   ```

6. **Communication Plan**
   ```
   @workspace:
   Draft security advisory:
   - What happened?
   - Who's affected?
   - What we're doing?
   - What users should do?
   ```

**Expected Outcome**: Vulnerability patched, users informed

**Time Estimate**: 1-4 hours + monitoring

---

## Team Collaboration Workflows

### 🎯 Workflow 15: PR Review Workflow

**When to use**: Reviewing pull requests

**Resources needed**:
- Instructions: `code-review-generic.instructions.md`, `security-and-owasp.instructions.md`
- Prompts: `dotnet-best-practices.prompt.md`, `conventional-commit.prompt.md`
- Agents: `gilfoyle.agent.md`, `se-security-reviewer.agent.md`, `accessibility.agent.md`

**Steps**:

1. **Initial Review**
   ```
   @workspace acting as gilfoyle.agent:
   Review PR: [PR number or git diff]
   Using code-review-generic.instructions
   ```

2. **Best Practices Check**
   ```
   @workspace using dotnet-best-practices.prompt:
   Check against .NET best practices:
   [changed files]
   ```

3. **Security Review**
   ```
   @workspace acting as se-security-reviewer.agent:
   Security implications of:
   [changed files]
   ```

4. **Accessibility Check**
   ```
   @workspace acting as accessibility.agent:
   Check accessibility of UI changes:
   [UI-related changes]
   ```

5. **Commit Message Review**
   ```
   @workspace using conventional-commit.prompt:
   Review commit messages:
   [commit list]
   ```

6. **Test Coverage**
   ```
   @workspace:
   Analyze test coverage for changes:
   [changed files]
   Suggest missing tests
   ```

7. **Provide Feedback**
   ```
   @workspace:
   Summarize review findings:
   - Critical issues (blocking)
   - Important suggestions
   - Nice-to-haves
   - Praise for good work
   ```

**Expected Outcome**: Thorough PR review with actionable feedback

**Time Estimate**: 30-60 minutes per PR

---

### 🎯 Workflow 16: Knowledge Transfer

**When to use**: Onboarding new team members or documenting system

**Resources needed**:
- Prompts: `code-tour.prompt.md` (if exists), `create-readme.prompt.md`, `documentation-writer.prompt.md`
- Agents: `code-tour.agent.md`, `se-technical-writer.agent.md`, `mentor.agent.md`

**Steps**:

1. **System Overview**
   ```
   @workspace acting as code-tour.agent:
   Create architectural overview of:
   @workspace
   Target audience: new team member
   ```

2. **Code Walkthrough**
   ```
   @workspace acting as code-tour.agent:
   Walk through key components:
   - Entry points
   - Core business logic
   - Data flow
   - External integrations
   ```

3. **README Documentation**
   ```
   @workspace using create-readme.prompt:
   Create comprehensive README covering:
   - Project overview
   - Setup instructions
   - Architecture
   - Development workflow
   - Common tasks
   ```

4. **Development Guide**
   ```
   @workspace acting as se-technical-writer.agent:
   Using documentation-writer.prompt:
   Create developer guide with:
   - Coding standards
   - Git workflow
   - Testing approach
   - Deployment process
   ```

5. **Mentorship Plan**
   ```
   @workspace acting as mentor.agent:
   Create 30-day onboarding plan:
   - Week 1: [tasks]
   - Week 2: [tasks]
   - Week 3: [tasks]
   - Week 4: [tasks]
   ```

**Expected Outcome**: Comprehensive documentation for new team members

**Time Estimate**: 4-8 hours

---

## Learning & Documentation Workflows

### 🎯 Workflow 17: Create Custom Instructions

**When to use**: Tailoring Copilot for your specific project/team

**Resources needed**:
- Prompts: `generate-custom-instructions-from-codebase.prompt.md`
- Agents: `context-architect.agent.md`, `prompt-engineer.agent.md`

**Steps**:

1. **Analyze Codebase**
   ```
   @workspace using generate-custom-instructions-from-codebase.prompt:
   Generate custom instructions for:
   @workspace
   ```

2. **Team Standards**
   ```
   @workspace acting as prompt-engineer.agent:
   Create instructions for our team standards:
   - Naming conventions: [describe]
   - Architecture pattern: Vertical Slice
   - Testing approach: TDD with xUnit
   - Documentation: XML comments required
   ```

3. **Context Optimization**
   ```
   @workspace acting as context-architect.agent:
   Using context-engineering.instructions:
   Optimize custom instructions for token efficiency
   ```

4. **Validate Instructions**
   ```
   Test custom instructions:
   @workspace using new custom instructions:
   [typical development task]
   Verify behavior matches expectations
   ```

5. **Share with Team**
   ```
   Document custom instructions:
   - Where to place them
   - What they do
   - When to update them
   ```

**Expected Outcome**: Project-specific Copilot instructions

**Time Estimate**: 2-4 hours

---

### 🎯 Workflow 18: Documentation Sprint

**When to use**: Comprehensive documentation update

**Resources needed**:
- Prompts: `create-readme.prompt.md`, `documentation-writer.prompt.md`, `create-architectural-decision-record.prompt.md`
- Agents: `se-technical-writer.agent.md`, `adr-generator.agent.md`

**Steps**:

1. **Audit Existing Docs**
   ```
   @workspace:
   Analyze existing documentation:
   - What's missing?
   - What's outdated?
   - What's incomplete?
   ```

2. **README Update**
   ```
   @workspace using create-readme.prompt:
   Update README.md with:
   [specific sections needed]
   ```

3. **API Documentation**
   ```
   @workspace acting as se-technical-writer.agent:
   Generate API documentation from:
   #file:src/[api-files]
   Include: endpoints, request/response, examples
   ```

4. **Architecture Docs**
   ```
   @workspace using architecture-blueprint-generator.prompt:
   Create architecture documentation:
   - System context
   - Container diagram
   - Component diagram
   ```

5. **ADRs**
   ```
   @workspace acting as adr-generator.agent:
   Document these architectural decisions:
   [list decisions]
   ```

6. **Code Documentation**
   ```
   @workspace using csharp-docs.prompt:
   Add XML documentation to:
   #file:src/[all-public-apis]
   ```

**Expected Outcome**: Complete, up-to-date documentation

**Time Estimate**: Full day to multiple days

---

## Workflow Combinations

### 🎯 Meta-Workflow: Full Feature Lifecycle

Combines multiple workflows for complete feature delivery:

1. **Planning Phase**
   - Workflow 15: Knowledge Transfer (understand context)
   - Workflow 9: Architecture Design (if needed)
   - Workflow 17: Custom Instructions (prepare environment)

2. **Development Phase**
   - Workflow 1: New API Endpoint (implementation)
   - Workflow 2: Database Operations (if needed)
   - Workflow 3: Async Implementation (if needed)

3. **Quality Phase**
   - Workflow 4: Comprehensive Test Suite
   - Workflow 5: Security Audit
   - Workflow 6: Code Quality Review

4. **DevOps Phase**
   - Workflow 7: CI/CD Pipeline Setup (if needed)
   - Workflow 8: Performance Optimization

5. **Documentation Phase**
   - Workflow 18: Documentation Sprint

6. **Review Phase**
   - Workflow 15: PR Review Workflow

**Time Estimate**: 2-4 weeks for major feature

---

## Tips for Workflow Success

1. **Start Small**: Don't use all agents/prompts at once
2. **Iterate**: Refine your workflow as you learn
3. **Document**: Save successful workflow combinations
4. **Customize**: Adapt workflows to your team's needs
5. **Measure**: Track time savings and quality improvements
6. **Share**: Teach team members effective workflows
7. **Automate**: Create scripts for common workflow steps

## Workflow Metrics

Track these to measure workflow effectiveness:

- **Time to Complete**: Compare before/after Copilot
- **Quality Indicators**: Bugs found, test coverage, security issues
- **Team Adoption**: % of team using workflows
- **Custom Workflows**: Team-created workflows
- **Efficiency Gains**: Tasks completed per sprint

---

*Workflows are living documents - update based on your experience!*
