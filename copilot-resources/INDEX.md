# Copilot Resources Index

Quick navigation for all GitHub Copilot resources.

## 📖 Documentation (Start Here!)

| File | Description | Read Time |
|------|-------------|-----------|
| [SUMMARY.txt](SUMMARY.txt) | Installation summary & quick start | 5 min |
| [README.md](README.md) | Comprehensive guide with all details | 30 min |
| [QUICK_REFERENCE.md](QUICK_REFERENCE.md) | Command patterns & cheatsheet | 10 min |
| [INSTALLATION.md](INSTALLATION.md) | Setup guide & troubleshooting | 15 min |
| [WORKFLOWS.md](WORKFLOWS.md) | 18 detailed development workflows | 45 min |

## 📋 Instructions (15 files)

Add these to .github/copilot-instructions.md for persistent guidance.

### Core .NET
- [csharp.instructions.md](instructions/csharp.instructions.md)
- [aspnet-rest-apis.instructions.md](instructions/aspnet-rest-apis.instructions.md)
- [csharp-mcp-server.instructions.md](instructions/csharp-mcp-server.instructions.md)
- [dotnet-architecture-good-practices.instructions.md](instructions/dotnet-architecture-good-practices.instructions.md)
- [dotnet-framework.instructions.md](instructions/dotnet-framework.instructions.md)
- [dotnet-upgrade.instructions.md](instructions/dotnet-upgrade.instructions.md)

### Quality & Process
- [code-review-generic.instructions.md](instructions/code-review-generic.instructions.md)
- [security-and-owasp.instructions.md](instructions/security-and-owasp.instructions.md)
- [performance-optimization.instructions.md](instructions/performance-optimization.instructions.md)
- [context-engineering.instructions.md](instructions/context-engineering.instructions.md)
- [task-implementation.instructions.md](instructions/task-implementation.instructions.md)

### DevOps & Infrastructure
- [containerization-docker-best-practices.instructions.md](instructions/containerization-docker-best-practices.instructions.md)
- [github-actions-ci-cd-best-practices.instructions.md](instructions/github-actions-ci-cd-best-practices.instructions.md)
- [azure-devops-pipelines.instructions.md](instructions/azure-devops-pipelines.instructions.md)
- [kubernetes-deployment-best-practices.instructions.md](instructions/kubernetes-deployment-best-practices.instructions.md)

## 🎨 Prompts (31 files)

Use with #file:copilot-resources/prompts/[name] in Copilot Chat.

### API & Web Development
- [aspnet-minimal-api-openapi.prompt.md](prompts/aspnet-minimal-api-openapi.prompt.md) - Generate OpenAPI specs
- [ef-core.prompt.md](prompts/ef-core.prompt.md) - Entity Framework Core operations

### C# & .NET
- [csharp-docs.prompt.md](prompts/csharp-docs.prompt.md) - Generate XML documentation
- [csharp-async.prompt.md](prompts/csharp-async.prompt.md) - Convert to async/await
- [dotnet-best-practices.prompt.md](prompts/dotnet-best-practices.prompt.md) - Best practices review
- [dotnet-design-pattern-review.prompt.md](prompts/dotnet-design-pattern-review.prompt.md) - Design patterns
- [dotnet-upgrade.prompt.md](prompts/dotnet-upgrade.prompt.md) - .NET version upgrade

### Testing
- [csharp-xunit.prompt.md](prompts/csharp-xunit.prompt.md) - Generate xUnit tests
- [csharp-nunit.prompt.md](prompts/csharp-nunit.prompt.md) - Generate NUnit tests
- [csharp-mstest.prompt.md](prompts/csharp-mstest.prompt.md) - Generate MSTest tests
- [breakdown-test.prompt.md](prompts/breakdown-test.prompt.md) - Plan test strategy

### Database
- [sql-code-review.prompt.md](prompts/sql-code-review.prompt.md) - SQL review
- [sql-optimization.prompt.md](prompts/sql-optimization.prompt.md) - SQL optimization

### Planning & Architecture
- [first-ask.prompt.md](prompts/first-ask.prompt.md) - Initial project questions
- [create-specification.prompt.md](prompts/create-specification.prompt.md) - Technical specs
- [create-implementation-plan.prompt.md](prompts/create-implementation-plan.prompt.md) - Implementation plan
- [update-implementation-plan.prompt.md](prompts/update-implementation-plan.prompt.md) - Update plan
- [breakdown-feature-implementation.prompt.md](prompts/breakdown-feature-implementation.prompt.md) - Break down features
- [breakdown-plan.prompt.md](prompts/breakdown-plan.prompt.md) - Work breakdown
- [architecture-blueprint-generator.prompt.md](prompts/architecture-blueprint-generator.prompt.md) - Architecture diagrams
- [code-exemplars-blueprint-generator.prompt.md](prompts/code-exemplars-blueprint-generator.prompt.md) - Code examples
- [create-architectural-decision-record.prompt.md](prompts/create-architectural-decision-record.prompt.md) - ADRs

### DevOps
- [create-github-action-workflow-specification.prompt.md](prompts/create-github-action-workflow-specification.prompt.md) - CI/CD workflows
- [multi-stage-dockerfile.prompt.md](prompts/multi-stage-dockerfile.prompt.md) - Docker multi-stage
- [conventional-commit.prompt.md](prompts/conventional-commit.prompt.md) - Commit messages

### Refactoring
- [refactor-plan.prompt.md](prompts/refactor-plan.prompt.md) - Refactoring plan
- [review-and-refactor.prompt.md](prompts/review-and-refactor.prompt.md) - Review & refactor

### Documentation
- [create-readme.prompt.md](prompts/create-readme.prompt.md) - Generate README
- [documentation-writer.prompt.md](prompts/documentation-writer.prompt.md) - Technical docs

### Utilities
- [github-copilot-starter.prompt.md](prompts/github-copilot-starter.prompt.md) - Getting started
- [generate-custom-instructions-from-codebase.prompt.md](prompts/generate-custom-instructions-from-codebase.prompt.md) - Custom instructions

## 🤖 Agents (33 files)

Reference with @workspace acting as [agent] in Copilot Chat.

### .NET Specialists
- [expert-dotnet-software-engineer.agent.md](agents/expert-dotnet-software-engineer.agent.md) - Senior .NET developer
- [CSharpExpert.agent.md](agents/CSharpExpert.agent.md) - C# language expert
- [csharp-dotnet-janitor.agent.md](agents/csharp-dotnet-janitor.agent.md) - Code cleanup

### Architecture & Design
- [api-architect.agent.md](agents/api-architect.agent.md) - API design expert
- [arch.agent.md](agents/arch.agent.md) - Software architect
- [adr-generator.agent.md](agents/adr-generator.agent.md) - ADR documentation
- [context-architect.agent.md](agents/context-architect.agent.md) - Context boundaries

### Planning
- [implementation-plan.agent.md](agents/implementation-plan.agent.md) - Implementation planning
- [plan.agent.md](agents/plan.agent.md) - General planning
- [planner.agent.md](agents/planner.agent.md) - Project planning
- [prd.agent.md](agents/prd.agent.md) - Product requirements
- [specification.agent.md](agents/specification.agent.md) - Technical specs
- [task-planner.agent.md](agents/task-planner.agent.md) - Task breakdown
- [task-researcher.agent.md](agents/task-researcher.agent.md) - Research & analysis

### TDD Workflow
- [tdd-red.agent.md](agents/tdd-red.agent.md) - Write failing tests
- [tdd-green.agent.md](agents/tdd-green.agent.md) - Make tests pass
- [tdd-refactor.agent.md](agents/tdd-refactor.agent.md) - Refactor code

### Code Review & Quality
- [gilfoyle.agent.md](agents/gilfoyle.agent.md) - Brutally honest reviewer
- [debug.agent.md](agents/debug.agent.md) - Debugging specialist
- [janitor.agent.md](agents/janitor.agent.md) - Code cleanup
- [se-security-reviewer.agent.md](agents/se-security-reviewer.agent.md) - Security review
- [se-system-architecture-reviewer.agent.md](agents/se-system-architecture-reviewer.agent.md) - Architecture review
- [critical-thinking.agent.md](agents/critical-thinking.agent.md) - Challenge assumptions

### DevOps
- [devops-expert.agent.md](agents/devops-expert.agent.md) - DevOps specialist
- [github-actions-expert.agent.md](agents/github-actions-expert.agent.md) - GitHub Actions

### Documentation & Communication
- [se-technical-writer.agent.md](agents/se-technical-writer.agent.md) - Technical writing
- [code-tour.agent.md](agents/code-tour.agent.md) - Code walkthrough

### Leadership & Mentorship
- [mentor.agent.md](agents/mentor.agent.md) - Development mentor
- [principal-software-engineer.agent.md](agents/principal-software-engineer.agent.md) - Technical leadership

### Specialized
- [accessibility.agent.md](agents/accessibility.agent.md) - Accessibility expert
- [tech-debt-remediation-plan.agent.md](agents/tech-debt-remediation-plan.agent.md) - Technical debt
- [prompt-builder.agent.md](agents/prompt-builder.agent.md) - Build prompts
- [prompt-engineer.agent.md](agents/prompt-engineer.agent.md) - Optimize prompts

## 🚀 Getting Started Paths

### Path 1: Beginner (Week 1)
1. Read [SUMMARY.txt](SUMMARY.txt)
2. Read [QUICK_REFERENCE.md](QUICK_REFERENCE.md)
3. Try [first-ask.prompt.md](prompts/first-ask.prompt.md)
4. Use [expert-dotnet-software-engineer.agent.md](agents/expert-dotnet-software-engineer.agent.md)
5. Generate tests with [csharp-xunit.prompt.md](prompts/csharp-xunit.prompt.md)

### Path 2: Intermediate (Week 2-4)
1. Set up [csharp.instructions.md](instructions/csharp.instructions.md)
2. Learn TDD with [tdd-red/green/refactor agents](agents/)
3. Use [planner.agent.md](agents/planner.agent.md) for features
4. Apply [dotnet-best-practices.prompt.md](prompts/dotnet-best-practices.prompt.md)
5. Review with [gilfoyle.agent.md](agents/gilfoyle.agent.md)

### Path 3: Advanced (Month 2+)
1. Read [WORKFLOWS.md](WORKFLOWS.md) - all 18 workflows
2. Create custom instructions with [generate-custom-instructions-from-codebase.prompt.md](prompts/generate-custom-instructions-from-codebase.prompt.md)
3. Use [arch.agent.md](agents/arch.agent.md) for design decisions
4. Implement [security-and-owasp.instructions.md](instructions/security-and-owasp.instructions.md)
5. Set up CI/CD with [github-actions-expert.agent.md](agents/github-actions-expert.agent.md)

### Path 4: Team Lead (Month 3+)
1. Train team on resources
2. Create team-specific workflows
3. Measure adoption and success metrics
4. Contribute improvements back to awesome-copilot
5. Build custom agents for your domain

## 🎯 Common Scenarios

| Scenario | Resources to Use |
|----------|------------------|
| **New API Endpoint** | api-architect.agent + aspnet-minimal-api-openapi.prompt + csharp.instructions |
| **Write Tests** | tdd-red.agent + csharp-xunit.prompt |
| **Code Review** | gilfoyle.agent + code-review-generic.instructions |
| **Security Audit** | se-security-reviewer.agent + security-and-owasp.instructions |
| **Performance Issue** | performance-optimization.instructions + sql-optimization.prompt |
| **Plan Feature** | planner.agent + create-implementation-plan.prompt |
| **Refactor Code** | janitor.agent + refactor-plan.prompt |
| **Bug Fix** | debug.agent + task-researcher.agent |
| **Documentation** | se-technical-writer.agent + documentation-writer.prompt |
| **Architecture Decision** | arch.agent + create-architectural-decision-record.prompt |

## 📞 Support

- **Questions?** Check [INSTALLATION.md](INSTALLATION.md) troubleshooting section
- **Workflows?** See [WORKFLOWS.md](WORKFLOWS.md) for 18 detailed workflows
- **Quick Help?** See [QUICK_REFERENCE.md](QUICK_REFERENCE.md)
- **Full Details?** Read [README.md](README.md)

## 🔗 External Links

- [github/awesome-copilot](https://github.com/github/awesome-copilot) - Upstream repository
- [GitHub Copilot Docs](https://docs.github.com/copilot) - Official documentation
- [VS Code Copilot](https://marketplace.visualstudio.com/items?itemName=GitHub.copilot) - Extension

---

**Total Resources**: 79 files (15 instructions + 31 prompts + 33 agents)

**Last Updated**: 2026-02-16

**Maintained by**: Curated from [github/awesome-copilot](https://github.com/github/awesome-copilot)
