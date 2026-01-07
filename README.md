# Exercicio IA avanzada Nav Meshes

Creei na ventana de Navigation un novo tipo de Agent chamado *Sphere*. 

Na escena FollowMouseClick, engadín un obxecto novo para o axente chamado *SphereAgent* co seu NavMeshAgent configurado e o tag IA para o AgentManager. 

Logo, engadín un novo NavMeshSurface para o Agent Type Sphere, pero creei un Obsexto fillo chamado SphereBlock cun NavMesh Modifier que só afecta aos Agents Sphere e que sobreescribe a area a *Not Walkable*, impedíndo así o paso do axente Sphere.
