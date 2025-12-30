# 🎯 SmartHabits - Aplicação Web de Gestão de Hábitos

> **Transforme sua vida, um hábito de cada vez**

Uma aplicação web moderna construída com **Blazor WebAssembly .NET 10** para ajudar você a desenvolver e manter hábitos saudáveis através de um sistema intuitivo de metas e acompanhamento diário.

## 🌟 Características Principais

### 🎨 **Interface Moderna**
- **Modo Claro/Escuro** com persistência de preferências
- **Design Responsivo** otimizado para desktop e mobile
- **Cores Vermelhas** como tema principal
- **Feedback Visual** com animações e indicadores de status

### 👤 **Sistema de Usuários**
- **Cadastro Seguro** com validação de senha forte (8+ caracteres, maiúsculas, minúsculas, números e símbolos)
- **Autenticação Completa** com login/logout
- **Perfil Personalizável** com foto, dados pessoais e alteração de senha
- **Navegação Condicional** baseada no status de autenticação

### 🎯 **Gestão de Hábitos**
- **Categorização Inteligente**: Saúde, Exercícios, Estudos, Trabalho, Social, Criatividade
- **CRUD Completo**: Criar, visualizar, editar e arquivar hábitos
- **Sistema de Metas** flexível (diária, semanal, mensal, personalizada)
- **Estatísticas Detalhadas**: Sequências, totais e histórico de atividades

### 📊 **Dashboard Interativo**
- **Visão Geral Inteligente** com métricas importantes
- **Marcação Diária** de atividades concluídas
- **Sistema de Sequências** para motivação contínua
- **Progresso Visual** com porcentagens e badges

## 🚀 Tecnologias Utilizadas

- **Frontend**: Blazor WebAssembly
- **Framework**: .NET 10
- **UI**: Bootstrap 5 + CSS Custom Properties
- **Persistência**: LocalStorage (dados mockados)
- **Validação**: DataAnnotations + Validação Customizada

## 📁 Estrutura do Projeto

```
src/SmartHabit.Client/
├── 📁 Layout/           # Componentes de layout
├── 📁 Models/          # Modelos de dados
├── 📁 Pages/           # Páginas da aplicação
│   ├── 📁 Habits/     # Páginas relacionadas a hábitos
│   ├── Dashboard.razor
│   ├── Login.razor
│   └── Register.razor
├── 📁 Services/        # Serviços e interfaces
├── 📁 State/          # Gestão de estado global
└── 📁 wwwroot/        # Recursos estáticos
    └── 📁 css/        # Estilos customizados
```

## 🛠️ Como Executar

### Pré-requisitos
- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- Navegador moderno (Chrome, Firefox, Edge, Safari)

### Execução Local
```bash
# 1. Clone o repositório
git clone <url-do-repositorio>

# 2. Navegue até o diretório do projeto
cd SmartHabit/WebClient

# 3. Restaure as dependências
dotnet restore

# 4. Execute a aplicação
dotnet run --project src/SmartHabit.Client

# 5. Acesse no navegador
# http://localhost:5254
```

### Build para Produção
```bash
dotnet publish src/SmartHabit.Client -c Release
```

## 📋 Funcionalidades Implementadas

### ✅ **Autenticação e Usuários**
- [x] Cadastro com validação completa de dados
- [x] Login seguro com hash de senha
- [x] Edição de perfil com upload de foto
- [x] Alteração de senha com validação robusta
- [x] Logout e gestão de sessão

### ✅ **Gestão de Hábitos**
- [x] Criar hábitos com título, descrição e categoria
- [x] Editar hábitos existentes
- [x] Arquivar/desativar hábitos
- [x] Visualizar lista completa de hábitos
- [x] Estatísticas individuais por hábito

### ✅ **Sistema de Metas**
- [x] Definir metas diárias, semanais, mensais
- [x] Metas personalizadas com período específico
- [x] Configurar duração alvo por sessão
- [x] Acompanhar progresso das metas

### ✅ **Dashboard e Acompanhamento**
- [x] Resumo geral de atividades
- [x] Marcar hábitos como concluídos
- [x] Sistema de sequências motivacionais
- [x] Métricas de progresso em tempo real

### ✅ **Interface e Experiência**
- [x] Tema claro/escuro com persistência
- [x] Design responsivo para todos os dispositivos
- [x] Validação em tempo real nos formulários
- [x] Feedback visual para todas as ações

## 🎮 Como Usar

### 1️⃣ **Primeiro Acesso**
1. Acesse a aplicação no navegador
2. Clique em "Cadastre-se" 
3. Preencha os dados com senha forte
4. Faça login com suas credenciais

### 2️⃣ **Criando Hábitos**
1. No dashboard, clique em "Novo Hábito"
2. Defina título, descrição e categoria
3. Salve o hábito

### 3️⃣ **Definindo Metas**
1. Acesse a página de hábitos
2. Clique em um hábito
3. Defina metas específicas (diária, semanal, etc.)
4. Configure duração se necessário

### 4️⃣ **Acompanhamento Diário**
1. Acesse o dashboard diariamente
2. Marque os hábitos realizados
3. Acompanhe suas sequências e estatísticas
4. Celebre seus progressos!

## 🎨 Personalização

### **Temas**
- Alterne entre modo claro e escuro usando o botão no cabeçalho
- As preferências são salvas automaticamente

### **Cores**
- Tema principal: Tons de vermelho (#dc2626)
- Personalize editando `wwwroot/css/variables.css`

## 🔒 Segurança

- **Validação Client-Side**: Todas as entradas são validadas
- **Senhas Seguras**: Requisitos obrigatórios de complexidade
- **Hash de Senhas**: Senhas nunca armazenadas em texto puro
- **Sanitização**: Prevenção contra XSS

## 📱 Compatibilidade

- **Navegadores**: Chrome 90+, Firefox 88+, Safari 14+, Edge 90+
- **Dispositivos**: Desktop, Tablet, Mobile
- **Resolução**: Responsivo para todas as telas

## 🔮 Roadmap Futuro

- [ ] Integração com API real
- [ ] Notificações push para lembretes
- [ ] Gráficos e relatórios avançados
- [ ] Sincronização entre dispositivos
- [ ] Sistema de conquistas e gamificação
- [ ] Export/import de dados
- [ ] Compartilhamento social de progressos

## 🤝 Contribuindo

1. Fork o projeto
2. Crie uma branch para sua feature (`git checkout -b feature/nova-funcionalidade`)
3. Commit suas mudanças (`git commit -am 'Adiciona nova funcionalidade'`)
4. Push para a branch (`git push origin feature/nova-funcionalidade`)
5. Abra um Pull Request

## 📄 Licença

Este projeto está sob a licença MIT. Veja o arquivo [LICENSE](LICENSE) para detalhes.

## 👨‍💻 Autor

Desenvolvido com ❤️ para ajudar pessoas a construírem hábitos transformadores.

---

**SmartHabits** - *Seu companheiro na jornada de desenvolvimento pessoal* 🌱
