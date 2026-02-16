# GitHub Copilot Resources for ASP.NET Core Development

This directory contains curated prompts, instructions, and agents from the [github/awesome-copilot](https://github.com/github/awesome-copilot) repository, specifically selected for .NET/ASP.NET Core application development.

## 📁 Directory Structure

```
copilot-resources/
├── instructions/     # Persistent instructions that guide Copilot's behavior
├── prompts/         # One-time prompts for specific tasks
├── agents/          # Specialized AI agents for different roles
└── README.md        # This file
```

## 🎯 How to Use These Resources

### Installing in VS Code Insiders

1. **Instructions** (Persistent Guidance):
   - Copy `.instructions.md` files to your workspace or global `.github/copilot-instructions.md`
   - They provide ongoing context for all Copilot interactions
   - Example: `csharp.instructions.md` guides C# coding standards

2. **Prompts** (One-Time Tasks):
   - Use with `@workspace` in Copilot Chat
   - Example: `#file:copilot-resources/prompts/aspnet-minimal-api-openapi.prompt.md`
   - Or reference directly: "Use the ef-core prompt to help me..."

3. **Agents** (Specialized Roles):
   - Reference in chat: `@workspace /explain using the api-architect agent`
   - Agents provide expert personas for specific tasks

## 📚 Available Resources

### Instructions (15 files)

#### Core .NET Development
- **csharp.instructions.md** - C# coding standards and best practices
- **aspnet-rest-apis.instructions.md** - ASP.NET Core REST API guidelines
- **csharp-mcp-server.instructions.md** - MCP server development in C#
- **dotnet-architecture-good-practices.instructions.md** - Architectural patterns
- **dotnet-framework.instructions.md** - .NET Framework specific guidance
- **dotnet-upgrade.instructions.md** - Upgrading .NET versions

#### Quality & Security
- **code-review-generic.instructions.md** - Code review standards
- **security-and-owasp.instructions.md** - Security best practices
- **performance-optimization.instructions.md** - Performance tuning

#### DevOps & Infrastructure
- **containerization-docker-best-practices.instructions.md** - Docker/containers
- **github-actions-ci-cd-best-practices.instructions.md** - CI/CD pipelines
- **azure-devops-pipelines.instructions.md** - Azure DevOps
- **kubernetes-deployment-best-practices.instructions.md** - K8s deployments

#### Workflow & Process
- **context-engineering.instructions.md** - Context management
- **task-implementation.instructions.md** - Task execution patterns

### Prompts (30 files)

#### API Development
- **aspnet-minimal-api-openapi.prompt.md** - Generate OpenAPI specs for Minimal APIs
  ```
  Use: Generate OpenAPI documentation for my API
  ```

#### Testing
- **csharp-xunit.prompt.md** - Generate xUnit tests
- **csharp-nunit.prompt.md** - Generate NUnit tests
- **csharp-mstest.prompt.md** - Generate MSTest tests
  ```
  Use: Create comprehensive unit tests for [class/method]
  ```

#### Code Quality
- **csharp-docs.prompt.md** - Generate XML documentation
- **csharp-async.prompt.md** - Convert sync code to async/await
- **dotnet-best-practices.prompt.md** - Review code against best practices
- **dotnet-design-pattern-review.prompt.md** - Analyze design patterns
  ```
  Use: Review this code for best practices
  ```

#### Database
- **ef-core.prompt.md** - Entity Framework Core operations
- **sql-code-review.prompt.md** - SQL code review
- **sql-optimization.prompt.md** - SQL performance optimization
  ```
  Use: Optimize this EF Core query
  ```

#### Project Management
- **create-specification.prompt.md** - Generate technical specifications
- **create-implementation-plan.prompt.md** - Create implementation plans
- **update-implementation-plan.prompt.md** - Update project plans
- **breakdown-feature-implementation.prompt.md** - Break down features
- **breakdown-plan.prompt.md** - Create work breakdown
- **breakdown-test.prompt.md** - Plan testing strategy
  ```
  Use: Create an implementation plan for [feature]
  ```

#### Architecture & Design
- **architecture-blueprint-generator.prompt.md** - Generate architecture diagrams
- **code-exemplars-blueprint-generator.prompt.md** - Create code examples
- **create-architectural-decision-record.prompt.md** - Document ADRs
  ```
  Use: Generate an ADR for using event sourcing
  ```

#### DevOps
- **create-github-action-workflow-specification.prompt.md** - CI/CD workflows
- **multi-stage-dockerfile.prompt.md** - Docker multi-stage builds
- **conventional-commit.prompt.md** - Conventional commit messages
  ```
  Use: Create a GitHub Actions workflow for deployment
  ```

#### Refactoring
- **refactor-plan.prompt.md** - Plan refactoring
- **review-and-refactor.prompt.md** - Review and refactor code
  ```
  Use: Create a refactoring plan for this legacy code
  ```

#### Documentation
- **create-readme.prompt.md** - Generate README files
- **documentation-writer.prompt.md** - Write technical docs
  ```
  Use: Generate a comprehensive README
  ```

#### Getting Started
- **first-ask.prompt.md** - Initial project questions
- **github-copilot-starter.prompt.md** - Copilot best practices
- **generate-custom-instructions-from-codebase.prompt.md** - Custom instructions
  ```
  Use: Generate custom instructions for my codebase
  ```

### Agents (33 files)

#### .NET Specialists
- **expert-dotnet-software-engineer.agent.md** - Senior .NET engineer
- **CSharpExpert.agent.md** - C# language expert
- **csharp-dotnet-janitor.agent.md** - Code cleanup specialist
  ```
  Role: Expert .NET developer with deep framework knowledge
  ```

#### Architecture & Design
- **api-architect.agent.md** - API design expert
- **arch.agent.md** - Software architect
- **adr-generator.agent.md** - ADR documentation
- **context-architect.agent.md** - Context boundary design
  ```
  Role: Design scalable, maintainable API architecture
  ```

#### Planning & Management
- **implementation-plan.agent.md** - Implementation planning
- **plan.agent.md** - General planning
- **planner.agent.md** - Project planning
- **prd.agent.md** - Product requirements
- **specification.agent.md** - Technical specifications
- **task-planner.agent.md** - Task breakdown
- **task-researcher.agent.md** - Research & analysis
  ```
  Role: Break down complex features into actionable tasks
  ```

#### Development Process
- **tdd-red.agent.md** - Write failing tests (Red phase)
- **tdd-green.agent.md** - Make tests pass (Green phase)
- **tdd-refactor.agent.md** - Refactor code (Refactor phase)
  ```
  Role: Guide through TDD workflow
  ```

#### Quality & Review
- **gilfoyle.agent.md** - Brutally honest code reviewer
- **debug.agent.md** - Debugging specialist
- **janitor.agent.md** - Code cleanup
- **se-security-reviewer.agent.md** - Security review
- **se-system-architecture-reviewer.agent.md** - Architecture review
- **critical-thinking.agent.md** - Challenge assumptions
  ```
  Role: Critical code review and security analysis
  ```

#### DevOps & CI/CD
- **devops-expert.agent.md** - DevOps specialist
- **github-actions-expert.agent.md** - GitHub Actions expert
  ```
  Role: Design and implement CI/CD pipelines
  ```

#### Documentation & Communication
- **se-technical-writer.agent.md** - Technical writing
- **code-tour.agent.md** - Code walkthrough
  ```
  Role: Create clear, comprehensive documentation
  ```

#### Mentorship
- **mentor.agent.md** - Development mentor
- **principal-software-engineer.agent.md** - Senior technical leadership
  ```
  Role: Guide developers and provide technical leadership
  ```

#### Accessibility
- **accessibility.agent.md** - Accessibility expert
  ```
  Role: Ensure WCAG compliance and accessibility
  ```

#### Technical Debt
- **tech-debt-remediation-plan.agent.md** - Technical debt planning
  ```
  Role: Identify and plan technical debt reduction
  ```

#### Prompt Engineering
- **prompt-builder.agent.md** - Build effective prompts
- **prompt-engineer.agent.md** - Prompt optimization
  ```
  Role: Create and optimize AI prompts
  ```

## 🚀 Workflow Examples

### 1. **Feature Development Workflow**
```
1. Use: prompt-builder.agent + first-ask.prompt
   → Clarify requirements and scope

2. Use: specification.agent + create-specification.prompt
   → Document technical specification

3. Use: planner.agent + create-implementation-plan.prompt
   → Break down into tasks

4. Use: api-architect.agent + aspnet-rest-apis.instructions
   → Design API structure

5. Use: tdd-red.agent + csharp-xunit.prompt
   → Write failing tests

6. Use: expert-dotnet-software-engineer.agent + csharp.instructions
   → Implement feature

7. Use: tdd-green.agent
   → Make tests pass

8. Use: tdd-refactor.agent + dotnet-best-practices.prompt
   → Refactor and optimize

9. Use: gilfoyle.agent + code-review-generic.instructions
   → Code review

10. Use: se-technical-writer.agent + documentation-writer.prompt
    → Document the feature
```

### 2. **API Development Workflow**
```
1. Use: api-architect.agent + architecture-blueprint-generator.prompt
   → Design API architecture

2. Use: aspnet-rest-apis.instructions + aspnet-minimal-api-openapi.prompt
   → Implement Minimal APIs with OpenAPI

3. Use: ef-core.prompt
   → Set up data access

4. Use: security-and-owasp.instructions + se-security-reviewer.agent
   → Security review

5. Use: csharp-xunit.prompt
   → Create integration tests

6. Use: create-github-action-workflow-specification.prompt
   → Set up CI/CD
```

### 3. **Code Quality Workflow**
```
1. Use: janitor.agent + csharp-dotnet-janitor.agent
   → Clean up code

2. Use: dotnet-design-pattern-review.prompt
   → Review design patterns

3. Use: refactor-plan.prompt + review-and-refactor.prompt
   → Plan and execute refactoring

4. Use: performance-optimization.instructions
   → Optimize performance

5. Use: csharp-docs.prompt
   → Add documentation

6. Use: gilfoyle.agent
   → Final review
```

### 4. **TDD Workflow**
```
1. Use: tdd-red.agent + breakdown-test.prompt
   → Plan test scenarios and write failing tests

2. Use: tdd-green.agent + expert-dotnet-software-engineer.agent
   → Implement minimal code to pass tests

3. Use: tdd-refactor.agent + dotnet-best-practices.prompt
   → Refactor while keeping tests green

4. Repeat cycle for each feature increment
```

### 5. **Legacy Code Modernization**
```
1. Use: task-researcher.agent + generate-custom-instructions-from-codebase.prompt
   → Understand existing codebase

2. Use: tech-debt-remediation-plan.agent
   → Identify technical debt

3. Use: dotnet-upgrade.prompt + dotnet-upgrade.instructions
   → Plan .NET version upgrade

4. Use: refactor-plan.prompt
   → Create refactoring strategy

5. Use: se-system-architecture-reviewer.agent
   → Review architecture changes

6. Use: breakdown-plan.prompt
   → Break into manageable chunks

7. Execute refactoring with TDD workflow
```

### 6. **DevOps Setup Workflow**
```
1. Use: devops-expert.agent + containerization-docker-best-practices.instructions
   → Containerize application

2. Use: multi-stage-dockerfile.prompt
   → Create optimized Dockerfile

3. Use: github-actions-expert.agent + github-actions-ci-cd-best-practices.instructions
   → Design CI/CD pipeline

4. Use: create-github-action-workflow-specification.prompt
   → Implement GitHub Actions

5. Use: kubernetes-deployment-best-practices.instructions
   → Plan K8s deployment
```

### 7. **Security Review Workflow**
```
1. Use: se-security-reviewer.agent + security-and-owasp.instructions
   → Security audit

2. Use: sql-optimization.prompt + sql-code-review.prompt
   → Review data access security

3. Use: critical-thinking.agent
   → Challenge security assumptions

4. Fix vulnerabilities with TDD workflow
```

### 8. **Documentation Workflow**
```
1. Use: code-tour.agent
   → Create code walkthrough

2. Use: architecture-blueprint-generator.prompt
   → Generate architecture diagrams

3. Use: create-architectural-decision-record.prompt
   → Document key decisions

4. Use: se-technical-writer.agent + documentation-writer.prompt
   → Write comprehensive docs

5. Use: create-readme.prompt
   → Generate README

6. Use: csharp-docs.prompt
   → Add XML documentation
```

### 9. **PR Review Workflow**
```
1. Use: gilfoyle.agent + code-review-generic.instructions
   → Initial code review

2. Use: se-security-reviewer.agent
   → Security check

3. Use: dotnet-best-practices.prompt
   → Best practices review

4. Use: critical-thinking.agent
   → Challenge design decisions

5. Use: accessibility.agent
   → Accessibility check

6. Use: conventional-commit.prompt
   → Verify commit messages
```

### 10. **Performance Optimization Workflow**
```
1. Use: task-researcher.agent
   → Identify bottlenecks

2. Use: performance-optimization.instructions
   → Apply optimization patterns

3. Use: sql-optimization.prompt
   → Optimize database queries

4. Use: csharp-async.prompt
   → Convert to async patterns

5. Use: expert-dotnet-software-engineer.agent
   → Implement optimizations

6. Validate with tests (TDD workflow)
```

## 💡 Best Practices

### Combining Resources
1. **Use Instructions + Agent + Prompt** together for best results
   - Example: `csharp.instructions` + `expert-dotnet-software-engineer.agent` + `aspnet-minimal-api-openapi.prompt`

2. **Layer Instructions** for comprehensive guidance
   - Base: `csharp.instructions`
   - Add: `aspnet-rest-apis.instructions`
   - Layer: `security-and-owasp.instructions`

3. **Sequential Agent Use** for complex tasks
   - Plan → Implement → Review → Document

### Context Management
- Use `context-engineering.instructions` to optimize token usage
- Reference specific files instead of pasting content
- Use workspace context with `@workspace`

### Iteration
- Start with planner/researcher agents
- Implement with specialist agents
- Review with critical agents (gilfoyle, security-reviewer)
- Document with technical writer

## 🔗 VS Code Insiders Install Links

### Setup Instructions

1. **Global Instructions**: Create `.github/copilot-instructions.md` in your user home
2. **Workspace Instructions**: Create `.github/copilot-instructions.md` in project root
3. **Reference Prompts**: Use `#file:copilot-resources/prompts/[prompt-name].prompt.md`

### Quick Install Command

```powershell
# Copy core instructions to workspace
Copy-Item .\copilot-resources\instructions\csharp.instructions.md .\.github\copilot-instructions.md

# Append additional instructions
Get-Content .\copilot-resources\instructions\aspnet-rest-apis.instructions.md | Add-Content .\.github\copilot-instructions.md
```

## 📝 Additional Recommendations

### Project Phases

**Phase 1: Planning** (Week 1)
- prompt-builder.agent → Define requirements
- specification.agent → Technical specs
- implementation-plan.agent → Task breakdown
- arch.agent → Architecture design

**Phase 2: Development** (Weeks 2-4)
- expert-dotnet-software-engineer.agent → Core development
- tdd-red/green/refactor.agent → TDD cycle
- CSharpExpert.agent → Complex problems

**Phase 3: Quality** (Week 5)
- gilfoyle.agent → Code review
- se-security-reviewer.agent → Security
- performance-optimization.instructions → Performance

**Phase 4: Deployment** (Week 6)
- devops-expert.agent → CI/CD
- github-actions-expert.agent → Automation
- kubernetes-deployment-best-practices.instructions → Deployment

**Phase 5: Documentation** (Week 7)
- se-technical-writer.agent → Documentation
- code-tour.agent → Walkthroughs
- create-readme.prompt → README

### Maintenance
- janitor.agent → Regular cleanup
- tech-debt-remediation-plan.agent → Quarterly debt review
- dotnet-upgrade.agent → Version upgrades

## 🎓 Learning Path

1. **Beginner**: Start with `first-ask.prompt` + `github-copilot-starter.prompt`
2. **Intermediate**: Use `expert-dotnet-software-engineer.agent` + core instructions
3. **Advanced**: Combine multiple agents for complex workflows
4. **Expert**: Create custom instructions with `generate-custom-instructions-from-codebase.prompt`

## 🔍 Troubleshooting

### If Copilot Doesn't Follow Instructions
1. Verify file is in `.github/copilot-instructions.md`
2. Check file format (Markdown)
3. Reload VS Code window
4. Reference explicitly: "Follow the csharp.instructions"

### If Prompts Don't Work
1. Use `#file:` syntax
2. Reference in chat: "Use the [prompt-name] prompt to..."
3. Copy prompt content directly if needed

### If Agents Aren't Effective
1. Be specific: "@workspace acting as api-architect agent"
2. Combine with instructions and prompts
3. Provide context with `@workspace`

## 📊 Metrics for Success

- **Code Quality**: Use gilfoyle.agent for regular reviews
- **Test Coverage**: TDD workflow with xunit prompts
- **Security**: Regular se-security-reviewer.agent audits
- **Performance**: performance-optimization.instructions application
- **Documentation**: Comprehensive docs with technical-writer.agent

## 🤝 Contributing

These resources are from [github/awesome-copilot](https://github.com/github/awesome-copilot). To contribute:
1. Submit to the upstream repository
2. Follow contribution guidelines
3. Share your custom workflows

## 📚 Additional Resources

- [GitHub Copilot Documentation](https://docs.github.com/copilot)
- [Awesome Copilot Repository](https://github.com/github/awesome-copilot)
- [Copilot Best Practices](https://github.com/github/awesome-copilot/blob/main/README.md)

---

**Note**: These resources are living documents. Update them as your project evolves and customize them to your team's needs.
