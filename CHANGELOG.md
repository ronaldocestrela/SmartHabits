# 📝 Changelog

Todas as mudanças notáveis neste projeto serão documentadas neste arquivo.

O formato é baseado em [Keep a Changelog](https://keepachangelog.com/pt-BR/1.0.0/),
e este projeto adere ao [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [1.0.0] - 2024-12-30

### 🎯 Lançamento Inicial

Primeira versão completa da aplicação **SmartHabits** - uma plataforma web moderna para gestão e acompanhamento de hábitos pessoais.

### ✨ Adicionado

#### 👤 **Sistema de Usuários**
- Cadastro completo com validação de dados (nome, sobrenome, email, telefone)
- Sistema de autenticação seguro com hash de senhas
- Validação de senha forte (8+ caracteres, maiúsculas, minúsculas, números, símbolos)
- Edição de perfil com upload de foto e alteração de senha
- Logout e gestão de sessão

#### 🎯 **Gestão de Hábitos**
- CRUD completo de hábitos (Criar, Ler, Atualizar, Arquivar)
- Sistema de categorização (Saúde, Exercícios, Estudos, Trabalho, Social, Criatividade, Outros)
- Estatísticas individuais por hábito (sequência atual, melhor sequência, total de conclusões)
- Soft delete para preservar histórico
- Timestamps de criação e última atividade

#### 📊 **Sistema de Metas**
- Metas flexíveis: diária, semanal, mensal e personalizada
- Configuração de duração alvo por sessão
- Acompanhamento de progresso em tempo real
- Períodos personalizados com data de início e fim

#### 🏠 **Dashboard Interativo**
- Visão geral com métricas importantes (total de hábitos, concluídos hoje, sequência atual, percentual de meta)
- Marcação de atividades como concluídas por dia
- Desmarcação de atividades se necessário
- Sistema de sequências motivacionais
- Cards informativos com estatísticas visuais

#### 🎨 **Interface e Experiência**
- Sistema de tema claro/escuro com persistência no LocalStorage
- Cores vermelhas como tema principal conforme especificação
- Design responsivo para desktop, tablet e mobile
- Validação em tempo real em todos os formulários
- Feedback visual para todas as ações (spinners, alertas, badges)
- Navegação condicional baseada em autenticação
- Animações suaves e transições

#### 🏗️ **Arquitetura e Tecnologia**
- Blazor WebAssembly .NET 10 para processamento client-side
- Padrão Repository com MockApiService para simulação de API
- State management reativo com AppState
- CSS Custom Properties para temas dinâmicos
- Injeção de dependências configurada
- LocalStorage para persistência de dados mockados

#### 📱 **Páginas Implementadas**
- **Dashboard** (`/`) - Visão geral e marcação de atividades
- **Login** (`/login`) - Autenticação com validação
- **Cadastro** (`/register`) - Registro com validação completa
- **Meus Hábitos** (`/habits`) - Lista completa com estatísticas
- **Novo Hábito** (`/habits/create`) - Criação com categorização
- **Editar Hábito** (`/habits/edit/{id}`) - Edição completa
- **Perfil** (`/profile`) - Edição de dados pessoais e senha
- **Nova Meta** (`/habits/{id}/goals/create`) - Definição de metas

#### 🔒 **Segurança e Validação**
- Validação client-side robusta com DataAnnotations
- Validação customizada para senhas fortes
- Sanitização de inputs para prevenção de XSS
- Hash de senhas com SHA256
- Verificação de propriedade de recursos por usuário

### 🏗️ **Modelos de Dados**
- **User**: Gestão completa de usuários com dados pessoais
- **Habit**: Hábitos com categorização e estatísticas
- **HabitGoal**: Metas flexíveis com tipos e durações
- **HabitCompletion**: Registro de atividades realizadas com timestamps

### 🎯 **Funcionalidades Específicas**
- Aplicação 100% client-side conforme especificação
- Dados completamente mockados via LocalStorage
- Sistema de cores escuras com vermelho primário
- Modo escuro como padrão
- Todas as validações de usuário implementadas
- Sistema completo de hábitos com metas
- Dashboard com marcação diária funcional

### 📈 **Métricas e Estatísticas**
- Contador de sequências atual e melhor sequência
- Total de atividades concluídas por hábito
- Percentual de meta diária alcançado
- Últimas atividades realizadas
- Progresso visual em tempo real

---

## 🔮 Próximas Versões Planejadas

### [1.1.0] - Planejado
- Integração com API real
- Notificações push para lembretes
- Sistema de backup/restauração

### [1.2.0] - Planejado  
- Gráficos e relatórios avançados
- Export/import de dados
- Modo offline

### [2.0.0] - Planejado
- Sistema de gamificação e conquistas
- Comunidade e compartilhamento
- Aplicativo mobile nativo

---

### Tipos de Mudanças
- `✨ Added` para novas funcionalidades
- `🔄 Changed` para mudanças em funcionalidades existentes
- `⚠️ Deprecated` para funcionalidades que serão removidas em breve
- `🗑️ Removed` para funcionalidades removidas
- `🔧 Fixed` para correções de bugs
- `🔒 Security` para vulnerabilidades corrigidas