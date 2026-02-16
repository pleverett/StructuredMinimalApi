# Quick Reference: Copilot Resources

## 🎯 Most Used Combinations

### Daily Development
```
Instruction: csharp.instructions.md + aspnet-rest-apis.instructions.md
Agent: expert-dotnet-software-engineer.agent.md
Prompt: csharp-xunit.prompt.md (for tests)
```

### API Design
```
Agent: api-architect.agent.md
Prompt: aspnet-minimal-api-openapi.prompt.md
Instructions: aspnet-rest-apis.instructions.md
```

### Code Review
```
Agent: gilfoyle.agent.md
Instructions: code-review-generic.instructions.md + security-and-owasp.instructions.md
Prompt: dotnet-best-practices.prompt.md
```

### Planning
```
Agent: planner.agent.md + specification.agent.md
Prompt: create-implementation-plan.prompt.md + breakdown-feature-implementation.prompt.md
```

### Testing
```
Agent: tdd-red.agent.md → tdd-green.agent.md → tdd-refactor.agent.md
Prompt: csharp-xunit.prompt.md
Instructions: csharp.instructions.md
```

## 📋 Command Patterns

### In VS Code Copilot Chat

```
# Reference a prompt
#file:copilot-resources/prompts/aspnet-minimal-api-openapi.prompt.md

# Use an agent persona
@workspace Acting as the API Architect agent, design a REST API for...

# Combine multiple resources
@workspace Using csharp.instructions and aspnet-rest-apis.instructions, with the expert-dotnet-software-engineer agent, implement...

# Reference and apply
Using #file:copilot-resources/prompts/ef-core.prompt.md, optimize my Entity Framework queries

# Agent + Prompt combo
@workspace As the TDD-Red agent, use #file:copilot-resources/prompts/csharp-xunit.prompt.md to write tests for...
```

## 🔥 Power User Tips

1. **Chain Agents**: Plan → Implement → Review → Document
   ```
   Step 1: @workspace planner.agent → create tasks
   Step 2: @workspace expert-dotnet-software-engineer.agent → implement
   Step 3: @workspace gilfoyle.agent → review
   Step 4: @workspace se-technical-writer.agent → document
   ```

2. **Layer Instructions**: Add to `.github/copilot-instructions.md`
   ```markdown
   <!-- Base C# guidance -->
   #include copilot-resources/instructions/csharp.instructions.md
   
   <!-- API specific -->
   #include copilot-resources/instructions/aspnet-rest-apis.instructions.md
   
   <!-- Security -->
   #include copilot-resources/instructions/security-and-owasp.instructions.md
   ```

3. **Context-Aware Development**:
   ```
   @workspace with context-engineering.instructions, analyze this codebase and suggest optimizations
   ```

## ⚡ Keyboard Shortcuts

- `Ctrl+I`: Inline Copilot
- `Ctrl+Shift+I`: Copilot Chat
- `Ctrl+Enter`: Accept suggestion
- `Alt+]`: Next suggestion
- `Alt+[`: Previous suggestion

## 📁 File Organization

```
your-project/
├── .github/
│   └── copilot-instructions.md    ← Active instructions
├── copilot-resources/              ← Reference library
│   ├── instructions/
│   ├── prompts/
│   ├── agents/
│   ├── README.md                   ← Full guide
│   └── QUICK_REFERENCE.md         ← This file
└── src/
```

## 🎨 Workflow Templates

### New Feature
```bash
# 1. Plan
@workspace planner.agent + first-ask.prompt → clarify requirements
@workspace specification.agent + create-specification.prompt → write spec
@workspace implementation-plan.agent + create-implementation-plan.prompt → break down tasks

# 2. Design
@workspace api-architect.agent + architecture-blueprint-generator.prompt → design

# 3. TDD
@workspace tdd-red.agent + csharp-xunit.prompt → write tests
@workspace tdd-green.agent + expert-dotnet-software-engineer.agent → implement
@workspace tdd-refactor.agent + dotnet-best-practices.prompt → refactor

# 4. Review
@workspace gilfoyle.agent + code-review-generic.instructions → review
@workspace se-security-reviewer.agent + security-and-owasp.instructions → security

# 5. Document
@workspace se-technical-writer.agent + documentation-writer.prompt → document
```

### Bug Fix
```bash
# 1. Investigate
@workspace debug.agent → analyze issue
@workspace task-researcher.agent → research solutions

# 2. Fix with TDD
@workspace tdd-red.agent → write failing test
@workspace expert-dotnet-software-engineer.agent → fix bug
@workspace tdd-green.agent → verify fix

# 3. Review
@workspace gilfoyle.agent → code review
@workspace se-security-reviewer.agent → security check
```

### Refactoring
```bash
# 1. Analyze
@workspace janitor.agent → identify issues
@workspace tech-debt-remediation-plan.agent → prioritize

# 2. Plan
@workspace refactor-plan.prompt → create strategy
@workspace breakdown-plan.prompt → break into tasks

# 3. Execute
@workspace tdd-refactor.agent → refactor with tests
@workspace review-and-refactor.prompt → iterative improvement

# 4. Verify
@workspace dotnet-design-pattern-review.prompt → patterns check
@workspace performance-optimization.instructions → performance
```

## 🎯 By Role

### Backend Developer
- **Daily**: expert-dotnet-software-engineer.agent + csharp.instructions
- **API**: api-architect.agent + aspnet-rest-apis.instructions
- **Data**: ef-core.prompt + sql-optimization.prompt

### DevOps Engineer
- **CI/CD**: github-actions-expert.agent + github-actions-ci-cd-best-practices.instructions
- **Containers**: containerization-docker-best-practices.instructions + multi-stage-dockerfile.prompt
- **Deploy**: kubernetes-deployment-best-practices.instructions

### Architect
- **Design**: arch.agent + architecture-blueprint-generator.prompt
- **Decisions**: adr-generator.agent + create-architectural-decision-record.prompt
- **Review**: se-system-architecture-reviewer.agent

### QA Engineer
- **Testing**: tdd agents + testing prompts
- **Coverage**: breakdown-test.prompt
- **Security**: se-security-reviewer.agent

### Tech Lead
- **Planning**: planner.agent + implementation-plan.agent
- **Review**: principal-software-engineer.agent + gilfoyle.agent
- **Mentoring**: mentor.agent

## 🚨 Emergency Scenarios

### Production Bug
```
1. debug.agent → quick analysis
2. task-researcher.agent → find solution
3. expert-dotnet-software-engineer.agent → hotfix
4. gilfoyle.agent → expedited review
5. devops-expert.agent → deploy
```

### Security Vulnerability
```
1. se-security-reviewer.agent → assess impact
2. security-and-owasp.instructions → remediation
3. tdd-red.agent → add security tests
4. expert-dotnet-software-engineer.agent → fix
5. critical-thinking.agent → challenge solution
6. Deploy with verification
```

### Performance Issue
```
1. task-researcher.agent → identify bottleneck
2. performance-optimization.instructions → analyze
3. sql-optimization.prompt → optimize queries
4. csharp-async.prompt → add async/await
5. Benchmark and deploy
```

## 📊 Quality Gates

Before committing:
- [ ] gilfoyle.agent review
- [ ] dotnet-best-practices.prompt check
- [ ] se-security-reviewer.agent scan
- [ ] Tests passing (TDD workflow)
- [ ] conventional-commit.prompt for message

Before PR:
- [ ] code-review-generic.instructions applied
- [ ] documentation-writer.prompt for docs
- [ ] accessibility.agent check
- [ ] performance-optimization.instructions review

Before release:
- [ ] se-system-architecture-reviewer.agent review
- [ ] security-and-owasp.instructions compliance
- [ ] create-readme.prompt for release notes

## 💎 Pro Tips

1. **Batch Operations**: Open multiple Copilot chat threads for parallel work
2. **Save Common Combos**: Create custom instructions file with your favorite combinations
3. **Iterate**: Start broad (planner), then narrow (specialist agents)
4. **Context is King**: Always use `@workspace` for project-aware responses
5. **Version Control**: Track changes to custom instructions in git

## 📚 Learn More

- Full documentation: `copilot-resources/README.md`
- Upstream repo: https://github.com/github/awesome-copilot
- GitHub Copilot docs: https://docs.github.com/copilot

---
*Last Updated: 2026-02-16*
